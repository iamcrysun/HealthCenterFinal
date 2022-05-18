using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Category = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Days",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false),
            //        DayOfWeek = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Days", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Nurce",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FullName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        WorkEx = table.Column<int>(type: "int", nullable: false),
            //        Closed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Nurce", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Shifts",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        number = table.Column<int>(type: "int", nullable: false),
            //        TimeofBegin = table.Column<TimeSpan>(type: "time", nullable: false),
            //        TimeofEnd = table.Column<TimeSpan>(type: "time", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Shifts", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Specialization",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SpecializationName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Specialization", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Streets",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Street = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        PlaceOfSee = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Streets", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeofProc",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeofProc", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserTypes",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false),
            //        UserType = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserTypes", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Doctor",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PlaceOfSee = table.Column<int>(type: "int", nullable: false),
            //        SpecializationID = table.Column<int>(type: "int", nullable: false),
            //        FullName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        CategoryID = table.Column<int>(type: "int", nullable: false),
            //        ZamEnd = table.Column<DateTime>(type: "date", nullable: true),
            //        Certificate = table.Column<bool>(type: "bit", nullable: false),
            //        ZamStart = table.Column<DateTime>(type: "date", nullable: true),
            //        Closed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Doctor", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Doctor_Categories",
            //            column: x => x.CategoryID,
            //            principalTable: "Categories",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Doctor_Specialization",
            //            column: x => x.SpecializationID,
            //            principalTable: "Specialization",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Patient",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Male = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        PlaceOfWork = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
            //        Document = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        StreetID = table.Column<int>(type: "int", nullable: false),
            //        Closed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Patient", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Patient_Patient",
            //            column: x => x.StreetID,
            //            principalTable: "Streets",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MakingProcedure",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProcedureID = table.Column<int>(type: "int", nullable: false),
            //        NurceID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MakingProcedure", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_MakingProcedure_Nurce",
            //            column: x => x.NurceID,
            //            principalTable: "Nurce",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_MakingProcedure_TypeofProc",
            //            column: x => x.ProcedureID,
            //            principalTable: "TypeofProc",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ScheduleProcedure",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Room = table.Column<int>(type: "int", nullable: false),
            //        DayID = table.Column<int>(type: "int", nullable: false),
            //        ProcedureID = table.Column<int>(type: "int", nullable: false),
            //        Count = table.Column<int>(type: "int", nullable: false),
            //        Closed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScheduleProcedure", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_ScheduleProcedure_Days",
            //            column: x => x.DayID,
            //            principalTable: "Days",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ScheduleProcedure_TypeofProc",
            //            column: x => x.ProcedureID,
            //            principalTable: "TypeofProc",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Schedule",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DoctorID = table.Column<int>(type: "int", nullable: false),
            //        Room = table.Column<int>(type: "int", nullable: false),
            //        dayofWeek = table.Column<int>(type: "int", nullable: false),
            //        ZamID = table.Column<int>(type: "int", nullable: true),
            //        ShiftID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Schedule", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Schedule_Days",
            //            column: x => x.dayofWeek,
            //            principalTable: "Days",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Schedule_Doctor",
            //            column: x => x.DoctorID,
            //            principalTable: "Doctor",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Schedule_Shifts",
            //            column: x => x.ShiftID,
            //            principalTable: "Shifts",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        DoctorID = table.Column<int>(type: "int", nullable: true),
            //        UserType = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Users_Doctor",
            //            column: x => x.DoctorID,
            //            principalTable: "Doctor",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Users_UserTypes",
            //            column: x => x.UserType,
            //            principalTable: "UserTypes",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DoctorSee",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DoctorID = table.Column<int>(type: "int", nullable: false),
            //        PatientID = table.Column<int>(type: "int", nullable: false),
            //        DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Visited = table.Column<bool>(type: "bit", nullable: true),
            //        ZamID = table.Column<int>(type: "int", nullable: true),
            //        Closed = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DoctorSee", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_DoctorSee_Doctor",
            //            column: x => x.DoctorID,
            //            principalTable: "Doctor",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DoctorSee_Patient",
            //            column: x => x.PatientID,
            //            principalTable: "Patient",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RecordInPatientFile",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientID = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Result = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        Diagnosis = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
            //        DoctorID = table.Column<int>(type: "int", nullable: true),
            //        NurseID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RecordInPatientFile", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_RecordInPatientFile_Doctor",
            //            column: x => x.DoctorID,
            //            principalTable: "Doctor",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RecordInPatientFile_Nurce",
            //            column: x => x.NurseID,
            //            principalTable: "Nurce",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_RecordInPatientFile_Patient",
            //            column: x => x.PatientID,
            //            principalTable: "Patient",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DoProc",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProcID = table.Column<int>(type: "int", nullable: false),
            //        RecordID = table.Column<int>(type: "int", nullable: false),
            //        PatientID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DoProc", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_DoProc_Patient",
            //            column: x => x.PatientID,
            //            principalTable: "Patient",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DoProc_RecordInPatientFile",
            //            column: x => x.RecordID,
            //            principalTable: "RecordInPatientFile",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DoProc_TypeofProc",
            //            column: x => x.ProcID,
            //            principalTable: "TypeofProc",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Medicaments",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RecordID = table.Column<int>(type: "int", nullable: false),
            //        Medicine = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Medicaments", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Medicaments_RecordInPatientFile",
            //            column: x => x.RecordID,
            //            principalTable: "RecordInPatientFile",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Procedure",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Date = table.Column<DateTime>(type: "date", nullable: false),
            //        Visited = table.Column<bool>(type: "bit", nullable: true),
            //        DoProcID = table.Column<int>(type: "int", nullable: false),
            //        ScheduleID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Procedure", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Procedure_DoProc",
            //            column: x => x.DoProcID,
            //            principalTable: "DoProc",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Procedure_ScheduleProcedure",
            //            column: x => x.ScheduleID,
            //            principalTable: "ScheduleProcedure",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Doctor_CategoryID",
            //    table: "Doctor",
            //    column: "CategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Doctor_SpecializationID",
            //    table: "Doctor",
            //    column: "SpecializationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoctorSee_DoctorID",
            //    table: "DoctorSee",
            //    column: "DoctorID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoctorSee_PatientID",
            //    table: "DoctorSee",
            //    column: "PatientID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoProc_PatientID",
            //    table: "DoProc",
            //    column: "PatientID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoProc_ProcID",
            //    table: "DoProc",
            //    column: "ProcID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoProc_RecordID",
            //    table: "DoProc",
            //    column: "RecordID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MakingProcedure_NurceID",
            //    table: "MakingProcedure",
            //    column: "NurceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MakingProcedure_ProcedureID",
            //    table: "MakingProcedure",
            //    column: "ProcedureID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Medicaments_RecordID",
            //    table: "Medicaments",
            //    column: "RecordID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Patient_StreetID",
            //    table: "Patient",
            //    column: "StreetID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Procedure_DoProcID",
            //    table: "Procedure",
            //    column: "DoProcID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Procedure_ScheduleID",
            //    table: "Procedure",
            //    column: "ScheduleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RecordInPatientFile_DoctorID",
            //    table: "RecordInPatientFile",
            //    column: "DoctorID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RecordInPatientFile_NurseID",
            //    table: "RecordInPatientFile",
            //    column: "NurseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RecordInPatientFile_PatientID",
            //    table: "RecordInPatientFile",
            //    column: "PatientID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Schedule_dayofWeek",
            //    table: "Schedule",
            //    column: "dayofWeek");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Schedule_DoctorID",
            //    table: "Schedule",
            //    column: "DoctorID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Schedule_ShiftID",
            //    table: "Schedule",
            //    column: "ShiftID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScheduleProcedure_DayID",
            //    table: "ScheduleProcedure",
            //    column: "DayID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScheduleProcedure_ProcedureID",
            //    table: "ScheduleProcedure",
            //    column: "ProcedureID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_DoctorID",
            //    table: "Users",
            //    column: "DoctorID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_UserType",
            //    table: "Users",
            //    column: "UserType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropTable(
        //        name: "DoctorSee");

        //    migrationBuilder.DropTable(
        //        name: "MakingProcedure");

        //    migrationBuilder.DropTable(
        //        name: "Medicaments");

        //    migrationBuilder.DropTable(
        //        name: "Procedure");

        //    migrationBuilder.DropTable(
        //        name: "Schedule");

        //    migrationBuilder.DropTable(
        //        name: "Users");

        //    migrationBuilder.DropTable(
        //        name: "DoProc");

        //    migrationBuilder.DropTable(
        //        name: "ScheduleProcedure");

        //    migrationBuilder.DropTable(
        //        name: "Shifts");

        //    migrationBuilder.DropTable(
        //        name: "UserTypes");

        //    migrationBuilder.DropTable(
        //        name: "RecordInPatientFile");

        //    migrationBuilder.DropTable(
        //        name: "Days");

        //    migrationBuilder.DropTable(
        //        name: "TypeofProc");

        //    migrationBuilder.DropTable(
        //        name: "Doctor");

        //    migrationBuilder.DropTable(
        //        name: "Nurce");

        //    migrationBuilder.DropTable(
        //        name: "Patient");

        //    migrationBuilder.DropTable(
        //        name: "Categories");

        //    migrationBuilder.DropTable(
        //        name: "Specialization");

        //    migrationBuilder.DropTable(
        //        name: "Streets");
        }
    }
}
