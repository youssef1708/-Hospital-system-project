/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/26/2022 12:02:39 AM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BILL') and o.name = 'FK_BILL_ISSUE_PATIENT')
alter table BILL
   drop constraint FK_BILL_ISSUE_PATIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GIVEN') and o.name = 'FK_GIVEN_GIVEN_PATIENT')
alter table GIVEN
   drop constraint FK_GIVEN_GIVEN_PATIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GIVEN') and o.name = 'FK_GIVEN_GIVEN2_MEDICINE')
alter table GIVEN
   drop constraint FK_GIVEN_GIVEN2_MEDICINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PATIENT') and o.name = 'FK_PATIENT_ASSIGN_ROOM')
alter table PATIENT
   drop constraint FK_PATIENT_ASSIGN_ROOM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RECORDS') and o.name = 'FK_RECORDS_HAS_PATIENT')
alter table RECORDS
   drop constraint FK_RECORDS_HAS_PATIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RECORDS') and o.name = 'FK_RECORDS_MAKE_DOCTOR')
alter table RECORDS
   drop constraint FK_RECORDS_MAKE_DOCTOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TREAT') and o.name = 'FK_TREAT_TREAT_PATIENT')
alter table TREAT
   drop constraint FK_TREAT_TREAT_PATIENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TREAT') and o.name = 'FK_TREAT_TREAT2_DOCTOR')
alter table TREAT
   drop constraint FK_TREAT_TREAT2_DOCTOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BILL')
            and   name  = 'ISSUE_FK'
            and   indid > 0
            and   indid < 255)
   drop index BILL.ISSUE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BILL')
            and   type = 'U')
   drop table BILL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DOCTOR')
            and   type = 'U')
   drop table DOCTOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GIVEN')
            and   name  = 'GIVEN2_FK'
            and   indid > 0
            and   indid < 255)
   drop index GIVEN.GIVEN2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GIVEN')
            and   name  = 'GIVEN_FK'
            and   indid > 0
            and   indid < 255)
   drop index GIVEN.GIVEN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GIVEN')
            and   type = 'U')
   drop table GIVEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEDICINE')
            and   type = 'U')
   drop table MEDICINE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PATIENT')
            and   name  = 'ASSIGN_FK'
            and   indid > 0
            and   indid < 255)
   drop index PATIENT.ASSIGN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PATIENT')
            and   type = 'U')
   drop table PATIENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RECORDS')
            and   name  = 'MAKE_FK'
            and   indid > 0
            and   indid < 255)
   drop index RECORDS.MAKE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RECORDS')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index RECORDS.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RECORDS')
            and   type = 'U')
   drop table RECORDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROOM')
            and   type = 'U')
   drop table ROOM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TREAT')
            and   name  = 'TREAT2_FK'
            and   indid > 0
            and   indid < 255)
   drop index TREAT.TREAT2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TREAT')
            and   name  = 'TREAT_FK'
            and   indid > 0
            and   indid < 255)
   drop index TREAT.TREAT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TREAT')
            and   type = 'U')
   drop table TREAT
go

/*==============================================================*/
/* Table: BILL                                                  */
/*==============================================================*/
create table BILL (
   PATIENT_ID_          varchar(20)          not null,
   AMOUNT               varchar(10)          null,
   TYPE                 varchar(10)          null,
   STATUS               varchar(10)          null
)
go

/*==============================================================*/
/* Index: ISSUE_FK                                              */
/*==============================================================*/
create index ISSUE_FK on BILL (
PATIENT_ID_ ASC
)
go

/*==============================================================*/
/* Table: DOCTOR                                                */
/*==============================================================*/
create table DOCTOR (
   DOCTOR_ID            varchar(30)          not null,
   PHONE_NUMBER         varchar(30)          null,
   DEPARTMENT_NAME_     varchar(25)          null,
   DRNAME               varchar(30)          null,
   AGE                  varchar(4)           null,
   constraint PK_DOCTOR primary key nonclustered (DOCTOR_ID)
)
go

/*==============================================================*/
/* Table: GIVEN                                                 */
/*==============================================================*/
create table GIVEN (
   PATIENT_ID_          varchar(20)          not null,
   ID                   varchar(35)          not null,
   constraint PK_GIVEN primary key (PATIENT_ID_, ID)
)
go

/*==============================================================*/
/* Index: GIVEN_FK                                              */
/*==============================================================*/
create index GIVEN_FK on GIVEN (
PATIENT_ID_ ASC
)
go

/*==============================================================*/
/* Index: GIVEN2_FK                                             */
/*==============================================================*/
create index GIVEN2_FK on GIVEN (
ID ASC
)
go

/*==============================================================*/
/* Table: MEDICINE                                              */
/*==============================================================*/
create table MEDICINE (
   ID                   varchar(35)          not null,
   PNAME                varchar(30)          null,
   PRICE                varchar(10)          null,
   DOSE                 varchar(40)          null,
   constraint PK_MEDICINE primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: PATIENT                                               */
/*==============================================================*/
create table PATIENT (
   PATIENT_ID_          varchar(20)          not null,
   ROOM_ID              varchar(10)          null,
   PNAME                varchar(30)          null,
   GENDER               varchar(8)           null,
   AGE                  varchar(4)           null,
   constraint PK_PATIENT primary key nonclustered (PATIENT_ID_)
)
go

/*==============================================================*/
/* Index: ASSIGN_FK                                             */
/*==============================================================*/
create index ASSIGN_FK on PATIENT (
ROOM_ID ASC
)
go

/*==============================================================*/
/* Table: RECORDS                                               */
/*==============================================================*/
create table RECORDS (
   RECORD_ID            varchar(20)          not null,
   PATIENT_ID_          varchar(20)          not null,
   DOCTOR_ID            varchar(30)          not null,
   TREATMENT            varchar(30)          null,
   DATE                 varchar(10)          null,
   constraint PK_RECORDS primary key nonclustered (RECORD_ID)
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on RECORDS (
PATIENT_ID_ ASC
)
go

/*==============================================================*/
/* Index: MAKE_FK                                               */
/*==============================================================*/
create index MAKE_FK on RECORDS (
DOCTOR_ID ASC
)
go

/*==============================================================*/
/* Table: ROOM                                                  */
/*==============================================================*/
create table ROOM (
   ROOM_ID              varchar(10)          not null,
   TYPE                 varchar(10)          null,
   STATUS               varchar(10)          null,
   constraint PK_ROOM primary key nonclustered (ROOM_ID)
)
go

/*==============================================================*/
/* Table: TREAT                                                 */
/*==============================================================*/
create table TREAT (
   PATIENT_ID_          varchar(20)          not null,
   DOCTOR_ID            varchar(30)          not null,
   constraint PK_TREAT primary key (PATIENT_ID_, DOCTOR_ID)
)
go

/*==============================================================*/
/* Index: TREAT_FK                                              */
/*==============================================================*/
create index TREAT_FK on TREAT (
PATIENT_ID_ ASC
)
go

/*==============================================================*/
/* Index: TREAT2_FK                                             */
/*==============================================================*/
create index TREAT2_FK on TREAT (
DOCTOR_ID ASC
)
go

alter table BILL
   add constraint FK_BILL_ISSUE_PATIENT foreign key (PATIENT_ID_)
      references PATIENT (PATIENT_ID_)
go

alter table GIVEN
   add constraint FK_GIVEN_GIVEN_PATIENT foreign key (PATIENT_ID_)
      references PATIENT (PATIENT_ID_)
go

alter table GIVEN
   add constraint FK_GIVEN_GIVEN2_MEDICINE foreign key (ID)
      references MEDICINE (ID)
go

alter table PATIENT
   add constraint FK_PATIENT_ASSIGN_ROOM foreign key (ROOM_ID)
      references ROOM (ROOM_ID)
go

alter table RECORDS
   add constraint FK_RECORDS_HAS_PATIENT foreign key (PATIENT_ID_)
      references PATIENT (PATIENT_ID_)
go

alter table RECORDS
   add constraint FK_RECORDS_MAKE_DOCTOR foreign key (DOCTOR_ID)
      references DOCTOR (DOCTOR_ID)
go

alter table TREAT
   add constraint FK_TREAT_TREAT_PATIENT foreign key (PATIENT_ID_)
      references PATIENT (PATIENT_ID_)
go

alter table TREAT
   add constraint FK_TREAT_TREAT2_DOCTOR foreign key (DOCTOR_ID)
      references DOCTOR (DOCTOR_ID)
go

