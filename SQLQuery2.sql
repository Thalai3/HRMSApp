use hrms;

Create Table Candidates(
Id int not null primary key Identity(1,1),
Candidate_Name  nvarchar(50) not null,
Date_of_Brith date not null,
Email_Address nvarchar(50) not null,
Mobile nvarchar(10) not null,
Alternate_Mobile nvarchar(10) not null,
Candidate_Address nvarchar(Max) not null,
Id_proof nvarchar(Max) not null,
Qualifications nvarchar(Max) not null,
Experience nvarchar(Max) not null,
Department nvarchar(Max) not null,
Job_Role nvarchar(Max) not null,
Candidate_Id nvarchar(Max) not null,
Interview_Date date not null,
Result nvarchar(30) not null)

select * from Candidates 


CREATE PROCEDURE Usp_AddCandidate @id int = null,@is_data char(1), @Name nvarchar(50),@DOB date,@Email nvarchar(50),
@Mobile nvarchar(10),@Alternate_Mobile nvarchar(10),@Candidate_Address nvarchar(Max),
@Id_proof nvarchar(Max),@Qualifications nvarchar(Max),@Experience nvarchar(Max),@Department nvarchar(Max),
@Job_Role nvarchar(Max),@Candidate_Id nvarchar(Max),@Interview_Date date,
@Result nvarchar(30)
AS
BEGIN
 --Add new Employees
 if (@is_data ='N')
 BEGIN
 insert into Candidates (Candidate_Name,Date_of_Brith,Email_Address,Mobile,Alternate_Mobile,Candidate_Address,Id_proof,Qualifications,Experience,
 Department,Job_Role,Candidate_Id,Interview_Date,Result) values(@Name,@DOB,@Email,@Mobile,@Alternate_Mobile,@Candidate_Address,@Id_proof,@Qualifications,
 @Experience,@Department,@Job_Role,@Candidate_Id,@Interview_Date,@Result);
 END
 --Update Employee
 if (@is_data ='U')
 BEGIN
 Update Candidates set Candidate_Name=@Name,Date_of_Brith=@DOB,Email_Address=@Email,Mobile=@Mobile,Alternate_Mobile=@Alternate_Mobile,Candidate_Address=@Candidate_Address,
 Id_proof=@Id_proof,Qualifications=@Qualifications,Experience=@Experience,Department=@Department,Job_Role=@Job_Role,Candidate_Id=@Candidate_Id,Interview_Date=@Interview_Date,
 Result=@Result where Id=@id;
 END
 --Delete Employee
 if(@is_data ='D')
 BEGIN
 Delete Candidates where Id=@Id;
 END
END
Go

Exec Usp_AddCandidate @is_data ='U',@id= 2,@Name ='Thalai',@DOB='11-03-2000',@Email='Thalai@gmail.com',@Mobile='8072357091',@Alternate_Mobile ='9806098685',@Candidate_Address ='',
@Id_proof='',@Qualifications ='',@Experience='',@Department='',@Job_Role='',@Candidate_Id='',@Interview_Date='11-03-2023',@Result='Selected'

--drop procedure Usp_AddCandidate
=============================================================================
day2 Qualification table creation


use hrms


select * from Candidates



Create Table tbl_Qualification(
Id int not null Primary key Identity(1,1),
Qualification nvarchar(Max) not null,
is_Active bit not null) 

select * from tbl_Qualification

insert into tbl_Qualification values('B.E',1)

--truncate table tbl_Qualification

Create Table tbl_Experience(
Id int not null Primary key Identity(1,1),
Experience nvarchar(max) not null,
is_Active bit not null default(1) 
)

insert into tbl_Experience values('0-6 Months','')

select * from tbl_Experience



