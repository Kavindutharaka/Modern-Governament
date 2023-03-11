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