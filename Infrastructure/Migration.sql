create database "JobBoardManagement"

create table Users
(
    UserId    serial primary key,
    FullName  varchar not null,
    Email     varchar unique,
    Phone     varchar unique,
    Role      varchar,
    CreatedAt timestamp
);

create table Jobs
(
    JobId       serial primary key,
    EmployerId  int references Users (UserId),
    Title       varchar,
    Description text,
    Salary      decimal,
    Country     varchar,
    City        varchar,
    Status      varchar,
    CreatedAt   timestamp,
    UpdatedAt   timestamp
);

create table Applications
(
    ApplicationId serial primary key,
    JobId         int references Jobs (JobId),
    ApplicantId   int references Users (UserId),
    Resume        text,
    Status        varchar,
    CreatedAt     timestamp,
    UpdatedAt     timestamp
);