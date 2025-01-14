USE [Clinic_db]
GO
/****** Object:  Table [dbo].[APPOINTMENT]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPOINTMENT](
	[AppointId] [int] IDENTITY(1,1) NOT NULL,
	[AppointDate] [date] NOT NULL,
	[TokenNumber] [int] NULL,
	[ConsultationId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[APPOINTMENT_DETAILS]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPOINTMENT_DETAILS](
	[TokenNumber] [int] NOT NULL,
	[Symptoms] [nvarchar](255) NULL,
	[Diagnosis] [nvarchar](255) NULL,
	[Medicine] [nvarchar](255) NULL,
	[LabTest] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
	[PatientId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TokenNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BILLING]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILLING](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentStatus] [varchar](30) NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[AppointId] [int] NULL,
	[MPId] [int] NULL,
	[TPId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONSULTATION]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONSULTATION](
	[ConsultationId] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NOT NULL,
	[TokenNumber] [int] NULL,
	[PatientId] [int] NULL,
	[Symptoms] [nvarchar](255) NULL,
	[Diagnosis] [nvarchar](255) NULL,
	[Medicine] [nvarchar](255) NULL,
	[LabTest] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConsultationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOGIN]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOGIN](
	[LoginId] [int] IDENTITY(100,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[StaffId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MEDICINE]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEDICINE](
	[MedicineId] [int] IDENTITY(100,1) NOT NULL,
	[MedicineName] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[UNIT] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MEDICINEPATIENTDETAILS]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEDICINEPATIENTDETAILS](
	[MPID] [int] IDENTITY(1,1) NOT NULL,
	[DOSAGE] [nvarchar](20) NOT NULL,
	[Duration] [int] NOT NULL,
	[PatientId] [int] NULL,
	[AppointId] [int] NULL,
	[MedicineId] [int] NULL,
	[ConsultationId] [int] NULL,
	[PrescriptionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PATIENT]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PATIENT](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[BloodGroup] [nvarchar](10) NOT NULL,
	[Gender] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESCRIPTION]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESCRIPTION](
	[PrescriptionId] [int] IDENTITY(1,1) NOT NULL,
	[Symptoms] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](100) NULL,
	[AppointId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUALIFICATION]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUALIFICATION](
	[QID] [int] IDENTITY(1,1) NOT NULL,
	[Qualification] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STAFF]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STAFF](
	[StaffId] [int] IDENTITY(1000,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[DOB] [date] NOT NULL,
	[BloodGroup] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[QID] [int] NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEST]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEST](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [nvarchar](50) NOT NULL,
	[Rate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TESTPATIENTDETAILS]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TESTPATIENTDETAILS](
	[TPID] [int] IDENTITY(1,1) NOT NULL,
	[SampleStatus] [nvarchar](30) NOT NULL,
	[Result] [nvarchar](30) NOT NULL,
	[NormalRange] [nvarchar](20) NOT NULL,
	[AppointId] [int] NULL,
	[PatientId] [int] NULL,
	[TestId] [int] NULL,
	[ConsultationId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[APPOINTMENT]  WITH CHECK ADD FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[CONSULTATION] ([ConsultationId])
GO
ALTER TABLE [dbo].[APPOINTMENT]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[PATIENT] ([PatientId])
GO
ALTER TABLE [dbo].[APPOINTMENT]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[STAFF] ([StaffId])
GO
ALTER TABLE [dbo].[APPOINTMENT_DETAILS]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[PATIENT] ([PatientId])
GO
ALTER TABLE [dbo].[BILLING]  WITH CHECK ADD FOREIGN KEY([AppointId])
REFERENCES [dbo].[APPOINTMENT] ([AppointId])
GO
ALTER TABLE [dbo].[BILLING]  WITH CHECK ADD FOREIGN KEY([MPId])
REFERENCES [dbo].[MEDICINEPATIENTDETAILS] ([MPID])
GO
ALTER TABLE [dbo].[BILLING]  WITH CHECK ADD FOREIGN KEY([TPId])
REFERENCES [dbo].[TESTPATIENTDETAILS] ([TPID])
GO
ALTER TABLE [dbo].[CONSULTATION]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[STAFF] ([StaffId])
GO
ALTER TABLE [dbo].[LOGIN]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[STAFF] ([StaffId])
GO
ALTER TABLE [dbo].[MEDICINEPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([AppointId])
REFERENCES [dbo].[APPOINTMENT] ([AppointId])
GO
ALTER TABLE [dbo].[MEDICINEPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[CONSULTATION] ([ConsultationId])
GO
ALTER TABLE [dbo].[MEDICINEPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([MedicineId])
REFERENCES [dbo].[MEDICINE] ([MedicineId])
GO
ALTER TABLE [dbo].[MEDICINEPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[PATIENT] ([PatientId])
GO
ALTER TABLE [dbo].[MEDICINEPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[PRESCRIPTION] ([PrescriptionId])
GO
ALTER TABLE [dbo].[PRESCRIPTION]  WITH CHECK ADD FOREIGN KEY([AppointId])
REFERENCES [dbo].[APPOINTMENT] ([AppointId])
GO
ALTER TABLE [dbo].[STAFF]  WITH CHECK ADD FOREIGN KEY([QID])
REFERENCES [dbo].[QUALIFICATION] ([QID])
GO
ALTER TABLE [dbo].[STAFF]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLES] ([RoleId])
GO
ALTER TABLE [dbo].[TESTPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([AppointId])
REFERENCES [dbo].[APPOINTMENT] ([AppointId])
GO
ALTER TABLE [dbo].[TESTPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([ConsultationId])
REFERENCES [dbo].[CONSULTATION] ([ConsultationId])
GO
ALTER TABLE [dbo].[TESTPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[PATIENT] ([PatientId])
GO
ALTER TABLE [dbo].[TESTPATIENTDETAILS]  WITH CHECK ADD FOREIGN KEY([TestId])
REFERENCES [dbo].[TEST] ([TestId])
GO
/****** Object:  StoredProcedure [dbo].[sp_BookAppointment]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BookAppointment]
    @AppointDate DATE,
    @TokenNumber INT,
    @PatientId INT,
    @StaffId INT,
    @ConsultationId INT
AS
BEGIN
    -- Insert a new record into the APPOINTMENT table
    INSERT INTO [dbo].[APPOINTMENT]
           ([AppointDate]
           ,[TokenNumber]
           ,[ConsultationId]
           ,[PatientId]
           ,[StaffId])
     VALUES
           (@AppointDate
           ,@TokenNumber
           ,@ConsultationId
           ,@PatientId
           ,@StaffId);

    -- Return the TokenNumber as the result
    SELECT @TokenNumber AS TokenNumber;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_BookAppointments]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BookAppointments]
    @AppointDate DATE,
    @TokenNumber INT,
    @ConsultationId INT,
    @PatientId INT,
    @StaffId INT,
    @AppointmentId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert the new appointment record
    INSERT INTO [dbo].[APPOINTMENT] 
    (
        [AppointDate],
        [TokenNumber],
        [ConsultationId],
        [PatientId],
        [StaffId]
    )
    VALUES
    (
        @AppointDate,
        @TokenNumber,
        @ConsultationId,
        @PatientId,
        @StaffId
    );

    -- Get the newly inserted AppointmentId
    SET @AppointmentId = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAppointments]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllAppointments]
AS
BEGIN
    -- Select all appointments from the APPOINTMENT table
    SELECT 
        TokenNumber AS TokenNo,
        AppointDate AS AppointmentDate,
        PatientId,
        ConsultationId,
        StaffId
    FROM 
        APPOINTMENT
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPatients]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPatients]
AS
BEGIN
    -- Select all patient details
    SELECT
        [PatientId],
        [FirstName],
        [LastName],
        [PhoneNumber],
        [Email],
        [Address],
        [DOB],
        [BloodGroup],
        [Gender]
    FROM [dbo].[PATIENT];
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppointmentByTokenNo]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAppointmentByTokenNo]
    @TokenNo INT
AS
BEGIN
    -- Select the appointment details from the APPOINTMENT table based on the given TokenNo
    SELECT 
        TokenNumber AS TokenNo,
        AppointDate AS AppointmentDate,
        PatientId,
        ConsultationId,
        StaffId
    FROM 
        APPOINTMENT
    WHERE 
        TokenNumber = @TokenNo;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPatientById]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPatientById]
    @PatientId INT
AS
BEGIN
    -- Select the patient details from the PATIENT table based on the given PatientId
    SELECT 
        PatientId,
        FirstName,
        LastName,
        DOB,
        BloodGroup,
        PhoneNumber,
        Email,
        Address,
        Gender
    FROM 
        PATIENT
    WHERE 
        PatientId = @PatientId;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserPass]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserPass]
                   @UserName NVARCHAR(20),
                   @password NVARCHAR(20),
                   @RoleId INT OUTPUT
AS
BEGIN
    SELECT @RoleId = RoleId
       FROM STAFF INNER JOIN LOGIN
       ON STAFF.StaffId = LOGIN.StaffId WHERE UserName = @UserName
             AND [password] = @password 
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertConsultationDetails]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertConsultationDetails]
    @TokenNo INT,
    @PatientId INT,
    @Symptoms NVARCHAR(255),
    @Diagnosis NVARCHAR(255),
    @Medicine NVARCHAR(255),
    @LabTest NVARCHAR(255) = NULL,
    @Note NVARCHAR(255)
AS
BEGIN
    -- Insert the consultation details into the APPOINTMENT_DETAILS table
    INSERT INTO APPOINTMENT_DETAILS (
        TokenNumber,
        PatientId,
        Symptoms,
        Diagnosis,
        Medicine,
        LabTest,
        Note
    )
    VALUES (
        @TokenNo,
        @PatientId,
        @Symptoms,
        @Diagnosis,
        @Medicine,
        @LabTest,
        @Note
    );
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPatient]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertPatient]
    @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
    @PhoneNumber BIGINT,
    @Email NVARCHAR(50) = NULL, -- Optional
    @Address NVARCHAR(50),
    @DOB DATE,
    @BloodGroup NVARCHAR(10),
    @Gender NVARCHAR(20) = NULL -- Optional
AS
BEGIN
    INSERT INTO [dbo].[PATIENT] (
        [FirstName],
        [LastName],
        [PhoneNumber],
        [Email],
        [Address],
        [DOB],
        [BloodGroup],
        [Gender]
    )
    VALUES (
        @FirstName,
        @LastName,
        @PhoneNumber,
        @Email,
        @Address,
        @DOB,
        @BloodGroup,
        @Gender
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePatient]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdatePatient]
    @PhoneNumber BIGINT,
    @FirstName NVARCHAR(20) = NULL,
    @LastName NVARCHAR(20) = NULL,
    @Email NVARCHAR(50) = NULL,
    @Address NVARCHAR(50) = NULL,
    @DOB DATE = NULL,
    @BloodGroup NVARCHAR(10) = NULL,
    @Gender NVARCHAR(20) = NULL
AS
BEGIN
    -- Check if a record with the provided phone number exists
    IF EXISTS (SELECT 1 FROM [dbo].[PATIENT] WHERE [PhoneNumber] = @PhoneNumber)
    BEGIN
        -- Update the patient record with the provided details
        UPDATE [dbo].[PATIENT]
        SET
            [FirstName] = COALESCE(@FirstName, [FirstName]),
            [LastName] = COALESCE(@LastName, [LastName]),
            [Email] = COALESCE(@Email, [Email]),
            [Address] = COALESCE(@Address, [Address]),
            [DOB] = COALESCE(@DOB, [DOB]),
            [BloodGroup] = COALESCE(@BloodGroup, [BloodGroup]),
            [Gender] = COALESCE(@Gender, [Gender])
        WHERE [PhoneNumber] = @PhoneNumber;
    END
    ELSE
    BEGIN
        -- Handle case where the phone number does not exist
        PRINT 'No patient found with the provided phone number.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[ssp_GetPatientDetailsByPhone]    Script Date: 27-08-2024 03:24:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ssp_GetPatientDetailsByPhone]
    @PhoneNumber BIGINT
AS
BEGIN
    -- Select patient details where the phone number matches
    SELECT
        [PatientId],
        [FirstName],
        [LastName],
        [PhoneNumber],
        [Email],
        [Address],
        [DOB],
        [BloodGroup],
        [Gender]
    FROM [dbo].[PATIENT]
    WHERE [PhoneNumber] = @PhoneNumber;
END;
GO
