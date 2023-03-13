create database  Government ;
use  Government ;
create table Login(username varchar(15),user_password varchar(15)); 
insert into login values ('officer1','123');
select * from Login;
create table BirthCertificate(reg_num varchar(10),full_name varchar(30),sex varchar(6),place_birth varchar(20),
dob date,f_name varchar(30),f_dob date,m_name varchar(20),m_dob date,date_reg date);
select * from BirthCertificate;
truncate table BirthCertificate;
create table MarriageCertificate(reg_num varchar(10),date_of_marriage date,fp_name varchar(30),fp_nic varchar(12),fp_dob date,fp_address varchar(30),fp_faname varchar(30),fp_moname varchar(30),fp_witness varchar(30),
sp_name varchar(30),sp_nic varchar(12),sp_dob date,sp_address varchar(30),sp_faname varchar(30),sp_moname varchar(30),sp_witness varchar(30));
select * from MarriageCertificate;
alter table MarriageCertificate add date_reg date;
create table DeathCertificate(reg_num varchar(10),Date_of_death date,Place_of_death varchar(20),full_name varchar(30),age int,sex varchar(8),father_name varchar(30),mother_name varchar(30),couse_of_death varchar(20),date_of_registration date);
select * from DeathCertificate;
create table driverlicen(reg_num varchar(10) primary key,nic varchar(13),fname varchar(30),dob date,sex varchar(8),age int,address varchar(30),tp int,height float,blood_group varchar(3),regdate date,expdate date);
alter table driverlicen ALTER COLUMN blood_group varchar(10);
select * from driverlicen;
insert into driverlicen values ('DL000003','123','kamal','2023-02-27','male',25,'malabe',0771454789,5.5,'o+','2023-03-12','2028-03-12');
ALTER TABLE driverlicen
alter table driverlicen add primary key(reg_num);
drop table driverlicen;
create table driverlicenUpdate(Licen_no varchar(10),M_report varchar(5),m_report_path varchar(255), 
foreign key(Licen_no) references driverlicen(reg_num));
select * from driverlicenUpdate;
alter table driverlicenUpdate add update_date date;
alter table driverlicenUpdate add exp_date date;
SELECT reg_num,nic,fname,dob,sex,age,tp,height,blood_group,regdate,expdate,M_report,m_report_path  
FROM driverlicen  
JOIN driverlicenUpdate  
ON driverlicen .reg_num = driverlicenUpdate.Licen_no;
insert into driverlicen values('DL000001',);
create table loan(loan_no varchar(12),cus_name varchar(30),cus_address varchar(30),nic varchar(15),reason varchar(20),job_name varchar(15),
job_address varchar(30),job_postion varchar(15),job_tp int,tp int,wit_name varchar(30),wit_address varchar(30),wit_tp int);
 