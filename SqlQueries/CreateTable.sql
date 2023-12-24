create table dotnet_crud.CrudApplication(
UserId int auto_increment primary key,
UserName varchar(255) Not Null,
EmailID varchar(255) Not Null,
MobileNumber varchar(255) default 'NA',
Gender varchar(10) default null,
IsActive bit default 1
);