using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<PrescriptionService> _logger;
    private readonly IAppointmentRepository _appointmentRepo;

    public PrescriptionService(
        IPrescriptionRepository repo,
        IAppointmentRepository appointmentRepo,
        IMapper mapper,
        ILogger<PrescriptionService> logger
    )
    {
        _repo = repo;
        _appointmentRepo = appointmentRepo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PrescriptionDTO?> GetByAppointmentIdAsync(int appointmentId)
    {
        var prescription = await _repo.GetByAppointmentIdAsync(appointmentId);
        return prescription == null ? null : _mapper.Map<PrescriptionDTO>(prescription);
    }

    public async Task<PrescriptionDTO> CreateAsync(CreatePrescriptionDTO dto)
    {
        var prescription = _mapper.Map<Prescription>(dto);
        prescription.CreatedAt = DateTime.UtcNow;
        prescription.Status = "Finalized"; // direct creates are finalized immediately

        foreach (var medDto in dto.Medicines)
            prescription.Medicines.Add(_mapper.Map<Medicine>(medDto));

        await _repo.AddAsync(prescription);
        await _repo.SaveAsync();
        _logger.LogInformation(
            "Prescription created for AppointmentId: {AppointmentId}",
            dto.AppointmentId
        );

        var created = await _repo.GetWithMedicinesAsync(prescription.Id);
        return _mapper.Map<PrescriptionDTO>(created!);
    }

    // NEW
    public async Task<PrescriptionResponseDTO> CreateSuggestionAsync(CreatePrescriptionDTO dto)
    {
        var appointment =
            await _appointmentRepo.GetByIdAsync(dto.AppointmentId)
            ?? throw new KeyNotFoundException($"Appointment {dto.AppointmentId} not found");

        if (appointment.Status == "Completed")
            throw new InvalidOperationException(
                "Cannot suggest a prescription for a completed appointment"
            );

        var prescription = _mapper.Map<Prescription>(dto);
        prescription.CreatedAt = DateTime.UtcNow;
        prescription.Status = "Suggested";

        foreach (var medDto in dto.Medicines)
            prescription.Medicines.Add(_mapper.Map<Medicine>(medDto));

        await _repo.AddAsync(prescription);
        await _repo.SaveAsync(); // no appointment update here anymore

        _logger.LogInformation(
            "Prescription suggested for AppointmentId: {AppointmentId}",
            dto.AppointmentId
        );

        var created = await _repo.GetWithMedicinesAsync(prescription.Id);
        return _mapper.Map<PrescriptionResponseDTO>(created!);
    }

    public async Task<PrescriptionResponseDTO> FinalizeAsync(int prescriptionId)
    {
        var prescription =
            await _repo.GetByIdAsync(prescriptionId)
            ?? throw new KeyNotFoundException($"Prescription {prescriptionId} not found");

        if (prescription.Status == "Finalized")
            throw new InvalidOperationException("Prescription is already finalized");

        // Mark prescription as finalized
        prescription.Status = "Finalized";
        _repo.Update(prescription);

        // Auto-complete the appointment
        var appointment =
            await _appointmentRepo.GetByIdAsync(prescription.AppointmentId)
            ?? throw new KeyNotFoundException(
                $"Appointment {prescription.AppointmentId} not found"
            );

        appointment.Status = "Completed";
        _appointmentRepo.Update(appointment);

        await _repo.SaveAsync();
        _logger.LogInformation(
            "Prescription {PrescriptionId} finalized, Appointment {AppointmentId} marked Completed",
            prescriptionId,
            prescription.AppointmentId
        );

        var updated = await _repo.GetWithMedicinesAsync(prescription.Id);
        return _mapper.Map<PrescriptionResponseDTO>(updated!);
    }
}
