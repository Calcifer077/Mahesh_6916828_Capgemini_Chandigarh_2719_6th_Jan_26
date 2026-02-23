create database insurance;

use insurance;

CREATE TABLE address_details (
    address_id INT PRIMARY KEY,
    h_no VARCHAR(6),
    city VARCHAR(50),
    addressline1 VARCHAR(50),
    state VARCHAR(50),
    pin VARCHAR(50)
);

CREATE TABLE user_details (
    user_id INT PRIMARY KEY,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    email VARCHAR(50),
    mobileno VARCHAR(50),
    address_id INT,
    dob DATE,
    CONSTRAINT FK_user_address
        FOREIGN KEY (address_id) REFERENCES address_details(address_id)
);

CREATE TABLE ref_policy_types (
    policy_type_code VARCHAR(10) PRIMARY KEY,
    policy_type_name VARCHAR(50)
);

CREATE TABLE policy_sub_types (
    policy_type_id VARCHAR(10) PRIMARY KEY,
    policy_type_code VARCHAR(10),
    description VARCHAR(50),
    yearsofpayements INT,
    amount DECIMAL(18,2),
    maturityperiod INT,
    maturityamount DECIMAL(18,2),
    validity INT,
    CONSTRAINT FK_policy_type
        FOREIGN KEY (policy_type_code)
        REFERENCES ref_policy_types(policy_type_code)
);

CREATE TABLE user_policies (
    policy_no VARCHAR(20) PRIMARY KEY,
    user_id INT,
    date_registered DATE,
    policy_type_id VARCHAR(10),
    CONSTRAINT FK_user_policy_user
        FOREIGN KEY (user_id) REFERENCES user_details(user_id),
    CONSTRAINT FK_user_policy_type
        FOREIGN KEY (policy_type_id) REFERENCES policy_sub_types(policy_type_id)
);

CREATE TABLE policy_payments (
    receipno INT PRIMARY KEY,
    user_id INT,
    policy_no VARCHAR(20),
    dateofpayment DATE,
    amount DECIMAL(18,2),
    fine DECIMAL(18,2),
    CONSTRAINT FK_payment_user
        FOREIGN KEY (user_id) REFERENCES user_details(user_id),
    CONSTRAINT FK_payment_policy
        FOREIGN KEY (policy_no) REFERENCES user_policies(policy_no)
);

INSERT INTO address_details VALUES (1,'6-21','hyderabad','kphb','andhrapradesh','1254');
INSERT INTO address_details VALUES (2,'7-81','chennai','seruseri','tamilnadu','16354');
INSERT INTO address_details VALUES (3,'3-71','lucknow','street','uttarpradesh','86451');
INSERT INTO address_details VALUES (4,'4-81','mumbai','iroli','maharashtra','51246');
INSERT INTO address_details VALUES (5,'5-81','bangalore','mgroad','karnataka','125465');
INSERT INTO address_details VALUES (6,'6-81','ahamadabad','street2','gujarat','125423');
INSERT INTO address_details VALUES (7,'9-21','chennai','sholinganur','tamilnadu','654286');

INSERT INTO user_details VALUES (1111,'raju','reddy','raju@gmail.com','9854261456',4,'1986-04-11');
INSERT INTO user_details VALUES (2222,'vamsi','krishna','vamsi@gmail.com','9854261463',1,'1990-04-11');
INSERT INTO user_details VALUES (3333,'naveen','reddy','naveen@gmail.com','9854261496',4,'1985-03-14');
INSERT INTO user_details VALUES (4444,'raghava','rao','raghava@gmail.com','9854261412',4,'1985-09-21');
INSERT INTO user_details VALUES (5555,'harsha','vardhan','harsha@gmail.com','9854261445',4,'1992-10-11');

INSERT INTO ref_policy_types VALUES ('58934','car');
INSERT INTO ref_policy_types VALUES ('58539','home');
INSERT INTO ref_policy_types VALUES ('58683','life');

INSERT INTO policy_sub_types VALUES ('6893','58934','theft',1,5000,NULL,200000,1);
INSERT INTO policy_sub_types VALUES ('6894','58934','accident',1,20000,NULL,200000,3);
INSERT INTO policy_sub_types VALUES ('6895','58539','fire',1,50000,NULL,500000,3);
INSERT INTO policy_sub_types VALUES ('6896','58683','anandhlife',7,50000,15,1500000,NULL);
INSERT INTO policy_sub_types VALUES ('6897','58683','sukhlife',10,5000,13,300000,NULL);

INSERT INTO user_policies VALUES ('689314',1111,'1994-04-18','6896');
INSERT INTO user_policies VALUES ('689316',1111,'2012-05-18','6895');
INSERT INTO user_policies VALUES ('689317',1111,'2012-06-20','6894');
INSERT INTO user_policies VALUES ('689318',2222,'2012-06-21','6894');
INSERT INTO user_policies VALUES ('689320',3333,'2012-06-18','6894');
INSERT INTO user_policies VALUES ('689420',4444,'2012-04-09','6896');

INSERT INTO policy_payments VALUES (121,4444,'689420','2012-04-09',50000,NULL);
INSERT INTO policy_payments VALUES (345,4444,'689420','2013-04-09',50000,NULL);
INSERT INTO policy_payments VALUES (300,1111,'689317','2012-06-20',20000,NULL);
INSERT INTO policy_payments VALUES (225,1111,'689316','2012-05-18',20000,NULL);
INSERT INTO policy_payments VALUES (227,1111,'689314','1994-04-18',50000,NULL);
INSERT INTO policy_payments VALUES (100,1111,'689314','1995-04-10',50000,NULL);
INSERT INTO policy_payments VALUES (128,1111,'689314','1996-04-11',50000,NULL);
INSERT INTO policy_payments VALUES (96,1111,'689314','1997-04-18',50000,200);
INSERT INTO policy_payments VALUES (101,1111,'689314','1998-04-09',50000,NULL);
INSERT INTO policy_payments VALUES (105,1111,'689314','1999-04-08',50000,NULL);
INSERT INTO policy_payments VALUES (120,1111,'689314','2000-04-05',50000,NULL);
INSERT INTO policy_payments VALUES (367,2222,'689318','2012-06-21',20000,NULL);
INSERT INTO policy_payments VALUES (298,3333,'689320','2012-06-18',20000,NULL);

select * from address_details;
select * from user_details;
select * from ref_policy_types;
select * from policy_sub_types;
select * from user_policies;
select * from policy_payments;

-- 1.
SELECT 
    pst.policy_type_id,
    rpt.policy_type_name,
    pst.description
FROM policy_sub_types pst
JOIN ref_policy_types rpt
    ON pst.policy_type_code = rpt.policy_type_code
WHERE rpt.policy_type_name = 'car';

-- 2.
SELECT 
    policy_type_code,
    COUNT(*) AS NO_OF_POLICIES
FROM policy_sub_types
GROUP BY policy_type_code;

-- 3.
SELECT 
    u.user_id,
    u.firstname,
    u.lastname,
    u.email,
    u.mobileno
FROM user_details u
JOIN address_details a
    ON u.address_id = a.address_id
WHERE LOWER(a.city) = 'chennai';

-- 4
SELECT DISTINCT
    u.user_id,
    (u.firstname + ' ' + u.lastname) AS USER_NAME,
    u.email,
    u.mobileno
FROM user_details u
JOIN user_policies up
    ON u.user_id = up.user_id
JOIN policy_sub_types pst
    ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt
    ON pst.policy_type_code = rpt.policy_type_code
WHERE rpt.policy_type_name = 'car';

-- 5. 
SELECT DISTINCT
    u.user_id,
    u.firstname,
    u.lastname
FROM user_details u
WHERE u.user_id IN (
        SELECT up.user_id
        FROM user_policies up
        JOIN policy_sub_types pst
            ON up.policy_type_id = pst.policy_type_id
        JOIN ref_policy_types rpt
            ON pst.policy_type_code = rpt.policy_type_code
        WHERE rpt.policy_type_name = 'car'
)
AND u.user_id NOT IN (
        SELECT up.user_id
        FROM user_policies up
        JOIN policy_sub_types pst
            ON up.policy_type_id = pst.policy_type_id
        JOIN ref_policy_types rpt
            ON pst.policy_type_code = rpt.policy_type_code
        WHERE rpt.policy_type_name = 'home'
);

-- 6. 
SELECT TOP 1
    rpt.policy_type_code,
    rpt.policy_type_name,
    COUNT(*) AS NO_OF_POLICIES
FROM policy_sub_types pst
JOIN ref_policy_types rpt
    ON pst.policy_type_code = rpt.policy_type_code
GROUP BY rpt.policy_type_code, rpt.policy_type_name
ORDER BY COUNT(*) DESC;


-- 7. 
SELECT 
    u.user_id,
    u.firstname,
    u.lastname,
    a.city,
    a.state
FROM user_details u
JOIN address_details a
    ON u.address_id = a.address_id
WHERE LOWER(a.city) LIKE '%bad';

-- 8. 
SELECT
    u.user_id,
    u.firstname,
    u.lastname,
    up.policy_no,
    up.date_registered
FROM user_details u
JOIN user_policies up
    ON u.user_id = up.user_id
WHERE up.date_registered < '2012-05-01';

-- 9. 
SELECT
    u.user_id,
    u.firstname,
    u.lastname
FROM user_details u
JOIN user_policies up
    ON u.user_id = up.user_id
GROUP BY u.user_id, u.firstname, u.lastname
HAVING COUNT(up.policy_no) > 1;

-- 10. 
SELECT
    rpt.policy_type_code,
    rpt.policy_type_name,
    pst.policy_type_id,
    up.user_id,
    up.policy_no
FROM user_policies up
JOIN policy_sub_types pst
    ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt
    ON pst.policy_type_code = rpt.policy_type_code
WHERE DATEADD(YEAR, pst.maturityperiod, up.date_registered)
      BETWEEN '2013-08-01' AND '2013-08-31';

-- 11
SELECT DISTINCT
    rpt.policy_type_code,
    rpt.policy_type_name,
    pst.policy_type_id
FROM policy_sub_types pst
JOIN ref_policy_types rpt
    ON pst.policy_type_code = rpt.policy_type_code
JOIN user_policies up
    ON pst.policy_type_id = up.policy_type_id
JOIN policy_payments pp
    ON up.policy_no = pp.policy_no
GROUP BY
    rpt.policy_type_code,
    rpt.policy_type_name,
    pst.policy_type_id,
    pst.maturityamount
HAVING pst.maturityamount = 2 * SUM(pp.amount);

-- 12. 
SELECT
    user_id,
    SUM(amount) AS total_amount
FROM policy_payments
GROUP BY user_id;

-- 13. 
SELECT
    user_id,
    policy_no,
    SUM(amount) AS total_amount
FROM policy_payments
GROUP BY user_id, policy_no;

-- 14. 
SELECT
    up.user_id,
    up.policy_no,
    pst.amount * pst.yearsofpayements - ISNULL(SUM(pp.amount),0) AS balance_amount
FROM user_policies up
JOIN policy_sub_types pst
    ON up.policy_type_id = pst.policy_type_id
LEFT JOIN policy_payments pp
    ON up.policy_no = pp.policy_no
GROUP BY
    up.user_id,
    up.policy_no,
    pst.amount,
    pst.yearsofpayements;

-- 15. 
SELECT
    up.user_id,
    up.policy_no,
    pst.yearsofpayements - COUNT(pp.receipno) AS BALANCE_YEARS
FROM user_policies up
JOIN policy_sub_types pst
    ON up.policy_type_id = pst.policy_type_id
LEFT JOIN policy_payments pp
    ON up.policy_no = pp.policy_no
GROUP BY
    up.user_id,
    up.policy_no,
    pst.yearsofpayements;

-- 16. Users who have taken car, home AND life
SELECT
    u.user_id,
    u.firstname,
    u.lastname
FROM user_details u
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
GROUP BY u.user_id, u.firstname, u.lastname
HAVING COUNT(DISTINCT rpt.policy_type_name) = 3;

-- 17. Total amount paid per policy department
SELECT
    rpt.policy_type_code,
    SUM(pp.amount) AS total_amount
FROM policy_payments pp
JOIN user_policies up ON pp.policy_no = up.policy_no
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
GROUP BY rpt.policy_type_code;


-- 18. 
SELECT
    u.user_id,
    (u.firstname + ' ' + u.lastname) AS user_name,
    pst.policy_type_code,
    pst.policy_type_id
FROM user_details u
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
GROUP BY
    u.user_id,
    u.firstname,
    u.lastname,
    pst.policy_type_code,
    pst.policy_type_id
HAVING COUNT(*) > 1;

-- 19. 
SELECT TOP 1
    rpt.policy_type_code,
    rpt.policy_type_name,
    COUNT(*) AS NO_OF_POLICIES
FROM user_policies up
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
GROUP BY rpt.policy_type_code, rpt.policy_type_name
ORDER BY COUNT(*) ASC;


-- 20. 

SELECT
    u.user_id,
    (u.firstname + ' ' + u.lastname) AS user_name,
    a.city + ', ' + a.state AS address,
    u.mobileno,
    rpt.policy_type_code,
    pst.policy_type_id,
    rpt.policy_type_name
FROM user_details u
JOIN address_details a ON u.address_id = a.address_id
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
LEFT JOIN policy_payments pp ON up.policy_no = pp.policy_no
GROUP BY
    u.user_id, u.firstname, u.lastname,
    a.city, a.state, u.mobileno,
    rpt.policy_type_code, pst.policy_type_id,
    rpt.policy_type_name,
    pst.yearsofpayements
HAVING COUNT(pp.receipno) >= pst.yearsofpayements;


-- 21.
SELECT TOP 2
    u.user_id,
    (u.firstname + ' ' + u.lastname) AS user_name,
    a.city + ', ' + a.state AS address,
    u.mobileno,
    rpt.policy_type_code,
    pst.policy_type_id,
    rpt.policy_type_name,
    up.date_registered
FROM user_details u
JOIN address_details a ON u.address_id = a.address_id
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
ORDER BY up.date_registered DESC;

