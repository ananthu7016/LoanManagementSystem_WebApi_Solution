Loan Management System (LMS)
----------------------------

Introduction
------------
This is the README documentation for the Loan Management System (LMS), an API project designed to manage loans, customers, staff, and related operations.

Database Structure
------------------


Create Database
---------------
CREATE DATABASE LMS_db; -- Shortform for LoanManagementSystem
USE LMS_db;


Tables:
------

Roles:
role_id (INT, auto-increment, primary key)
role_name (VARCHAR(20))


Users:
user_id (INT, auto-increment, primary key)
user_name (VARCHAR(30))
password (VARCHAR(30))
role_id (INT, foreign key references Roles(role_id))



Staffs:
staff_id (INT, auto-increment, primary key)
staff_first_name (VARCHAR(25))
staff_last_name (VARCHAR(10))
staff_address (VARCHAR(60))
staff_gender (CHAR(1))
staff_phone (VARCHAR(10))
staff_email (VARCHAR(20))
user_id (INT, foreign key references Users(user_id))
staff_status (BIT)


Customers:
cust_id (INT, auto-increment, primary key)
cust_first_name (VARCHAR(25))
cust_last_name (VARCHAR(10))
cust_occupation (VARCHAR(35))
cust_address (VARCHAR(60))
cust_phone (VARCHAR(10))
cust_aadhar (VARCHAR(12))
cust_gender (CHAR(1))
cust_dob (DATE)
cust_nationality (VARCHAR(20))
cust_annual_income (DECIMAL(10,2))
cust_employment_status (BIT)
cust_marital_status (BIT)
user_id (INT, foreign key references Users(user_id))
cust_status (BIT)


LoanCategory:
category_id (INT, auto-increment, primary key)
category_name (VARCHAR(30))


Loans:
loan_id (INT, auto-increment, primary key)
loan_name (VARCHAR(35))
category_id (INT, foreign key references LoanCategory(category_id))
loan_minimum_amount (DECIMAL(18,2))
loan_maximum_amount (DECIMAL(18,2))
loan_intrest_rate (DECIMAL(10,2))
late_payment_penalty (DECIMAL(10,2))
loan_term (INT)
loan_status (BIT)


LoanDetails:
detail_id (INT, auto-increment, primary key)
loan_id (INT, foreign key references Loans(loan_id))
cust_id (INT, foreign key references Customers(cust_id))
loan_amount (DECIMAL(18,2))
loan_request_date (DATE)
loan_sanction_date (DATE)
repayment_frequency (INT)
total_amount_repaid (DECIMAL(18,2))
outstanding_balance (DECIMAL(18,2))
late_payment_penalty (DECIMAL(10,2))
loan_status (BIT)


LoanRequests:
request_id (INT, auto-increment, primary key)
loan_id (INT, foreign key references Loans(loan_id))
cust_id (INT, foreign key references Customers(cust_id))
loan_request_date (DATE)
loan_purpose (VARCHAR(300))
requested_amount (DECIMAL(18,2))
repayment_frequency (INT)
request_status (BIT)

LoanVerification:
verification_id (INT, auto-increment, primary key)
request_id (INT, foreign key references LoanRequests(request_id))
staff_id (INT, foreign key references Staffs(staff_id))
verification_review (VARCHAR(500))
verification_status (BIT)








