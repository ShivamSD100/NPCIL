using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPCIL.Migrations
{
    public partial class LogSchema31072024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LogMessage = table.Column<string>(unicode: false, nullable: true),
                    ExceptionMessage = table.Column<string>(unicode: false, nullable: true),
                    StackTrace = table.Column<string>(unicode: false, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Logs__5E5486486551B04B", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AddMenu",
                columns: table => new
                {
                    menu_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_name_eng = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    menu_name_hind = table.Column<string>(nullable: true),
                    menu_position = table.Column<int>(nullable: true),
                    menu_type = table.Column<int>(nullable: true),
                    menu_img = table.Column<string>(unicode: false, nullable: true),
                    menu_desc_eng = table.Column<string>(unicode: false, nullable: true),
                    menu_desc_hind = table.Column<string>(nullable: true),
                    content_eng = table.Column<string>(unicode: false, nullable: true),
                    Content_hind = table.Column<string>(nullable: true),
                    file_image = table.Column<string>(unicode: false, nullable: true),
                    file_Startdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    file_Enddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    link_urlname = table.Column<string>(unicode: false, nullable: true),
                    linkType = table.Column<int>(nullable: true),
                    eventyear = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    menu_createdby = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    menu_createddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    menu_updatedby = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    menu_updateddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tab_active = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Controller = table.Column<string>(unicode: false, nullable: true),
                    menuOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AddMenu", x => x.menu_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Banner",
                columns: table => new
                {
                    ban_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ban_title = table.Column<string>(unicode: false, nullable: true),
                    ban_titleLang = table.Column<string>(nullable: true),
                    ban_uploadImg = table.Column<string>(unicode: false, nullable: true),
                    ban_linkURL = table.Column<string>(unicode: false, nullable: true),
                    ban_altTag = table.Column<string>(unicode: false, nullable: true),
                    ban_altTagLang = table.Column<string>(nullable: true),
                    ban_createdBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ban_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ban_updatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ban_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Banner", x => x.ban_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Category",
                columns: table => new
                {
                    ct_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ct_name = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ct_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ct_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ct_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ct_updateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Category", x => x.ct_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Content",
                columns: table => new
                {
                    con_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    con_name = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    con_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    con_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    con_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    con_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Content", x => x.con_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ContentManager",
                columns: table => new
                {
                    CM_Sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CM_name_eng = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CM_name_hind = table.Column<string>(nullable: true),
                    CM_position = table.Column<int>(nullable: true),
                    CM_type = table.Column<int>(nullable: true),
                    CM_PageContent_eng = table.Column<string>(unicode: false, nullable: true),
                    CM_PageContent_hind = table.Column<string>(nullable: true),
                    CM_startdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CM_enddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CM_image = table.Column<string>(unicode: false, nullable: true),
                    CM_shortDescEng = table.Column<string>(unicode: false, nullable: true),
                    CM_shortDescHind = table.Column<string>(nullable: true),
                    CM_createdby = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CM_createddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CM_updatedby = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CM_updateddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Menu_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ContentManager", x => x.CM_Sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HorizontalNews",
                columns: table => new
                {
                    HN_Sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HN_Lang = table.Column<int>(nullable: true),
                    HN_Content = table.Column<int>(nullable: true),
                    HN_Title = table.Column<string>(unicode: false, nullable: true),
                    HN_Description = table.Column<string>(unicode: false, nullable: true),
                    HN_StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HN_EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HN_CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    HN_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HN_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    HN_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HN_IsArchived = table.Column<bool>(nullable: true),
                    HN_ArchivedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HorizontalNews", x => x.HN_Sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Language",
                columns: table => new
                {
                    lang_sno = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    lang_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    lang_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    lang_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    lang_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Language", x => x.lang_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_linkType",
                columns: table => new
                {
                    link_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_linkType", x => x.link_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MenuPosition",
                columns: table => new
                {
                    mp_sno = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mp_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    mp_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mp_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    mp_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mp_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MenuPosition", x => x.mp_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MenuType",
                columns: table => new
                {
                    mt_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mt_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mt_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mt_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    mt_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mt_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MenuType", x => x.mt_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PageName",
                columns: table => new
                {
                    pgn_sno = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pgn_name = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    pgn_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pgn_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    pgn_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pgn_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PageName", x => x.pgn_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PhotoCategory",
                columns: table => new
                {
                    PhC_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhC_Title = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PhC_CreatedBy = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    PhC_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PhC_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PhC_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_PhotoGallery",
                columns: table => new
                {
                    Ph_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ph_category = table.Column<int>(nullable: true),
                    Ph_title = table.Column<string>(unicode: false, nullable: true),
                    Ph_title_reg = table.Column<string>(unicode: false, nullable: true),
                    Ph_description = table.Column<string>(unicode: false, nullable: true),
                    Ph_description_reg = table.Column<string>(unicode: false, nullable: true),
                    Ph_tag = table.Column<string>(unicode: false, nullable: true),
                    Ph_tag_reg = table.Column<string>(unicode: false, nullable: true),
                    Ph_image = table.Column<string>(unicode: false, nullable: true),
                    Ph_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Ph_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ph_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Ph_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PhotoGallery", x => x.Ph_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PressRelease",
                columns: table => new
                {
                    PR_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PR_Language = table.Column<int>(nullable: true),
                    PR_Content = table.Column<int>(nullable: true),
                    PR_Title = table.Column<string>(nullable: true),
                    PR_PageDescription = table.Column<string>(nullable: true),
                    PR_FileUpload = table.Column<string>(nullable: true),
                    PR_LinkURL = table.Column<string>(nullable: true),
                    PR_StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PR_EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PR_CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PR_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PR_UpdatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PR_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PressRelease", x => x.PR_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Publication",
                columns: table => new
                {
                    Pub_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pub_Language = table.Column<int>(nullable: true),
                    Pub_Type = table.Column<int>(nullable: true),
                    Pub_Title = table.Column<string>(unicode: false, nullable: true),
                    Pub_AuthorName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Pub_FileUpload = table.Column<string>(unicode: false, nullable: true),
                    Pub_Others = table.Column<string>(unicode: false, nullable: true),
                    Pub_CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Pub_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Pub_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Pub_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Publication", x => x.Pub_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PublicationCategories",
                columns: table => new
                {
                    PC_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PC_title = table.Column<string>(unicode: false, nullable: true),
                    PC_titleLang = table.Column<string>(nullable: true),
                    PC_uploadImg = table.Column<string>(unicode: false, nullable: true),
                    PC_linkURL = table.Column<string>(unicode: false, nullable: true),
                    PC_altTag = table.Column<string>(unicode: false, nullable: true),
                    PC_altTagLang = table.Column<string>(nullable: true),
                    PC_createdBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PC_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PC_updatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PC_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_PublicationType",
                columns: table => new
                {
                    pt_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pt_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pt_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pt_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    pt_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    pt_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PublicationType", x => x.pt_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PublicAwareness",
                columns: table => new
                {
                    PA_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PA_Language = table.Column<int>(nullable: true),
                    PA_Content = table.Column<int>(nullable: true),
                    PA_Title = table.Column<string>(nullable: true),
                    PA_PageDescription = table.Column<string>(nullable: true),
                    PA_FileUpload = table.Column<string>(nullable: true),
                    PA_LinkURL = table.Column<string>(nullable: true),
                    PA_StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PA_EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PA_CreatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PA_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PA_UpdatedBy = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PA_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_Status",
                columns: table => new
                {
                    st_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    st_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    st_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    st_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    st_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    st_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Status", x => x.st_sno);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tender",
                columns: table => new
                {
                    Tender_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendor_no = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Tendor_IssuingAuth_eng = table.Column<string>(unicode: false, nullable: true),
                    Tendor_IssuingAuth_hindi = table.Column<string>(nullable: true),
                    Tender_StartDate_SellingTender = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_EndDate_SellingTender = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_DateOpening = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_StartDate_ReceivingTender = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_EndDate_ReceivingTender = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_Prebid_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_Scope_eng = table.Column<string>(unicode: false, nullable: true),
                    Tender_Scope_hindi = table.Column<string>(nullable: true),
                    Tender_body_eng = table.Column<string>(unicode: false, nullable: true),
                    Tender_body_hindi = table.Column<string>(nullable: true),
                    Tender_markImportant = table.Column<bool>(nullable: true),
                    Tender_cost = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Tender_EMD = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Tender_IsArchived = table.Column<bool>(nullable: true),
                    Tender_archived_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_Createdby = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Tender_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tender_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Tender_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TenderType = table.Column<int>(nullable: true),
                    TenderURL = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    TenderUpload = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    TenderPosition = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tender", x => x.Tender_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TenderPosition",
                columns: table => new
                {
                    TP_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TP_Title = table.Column<string>(maxLength: 200, nullable: true),
                    TP_CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    TP_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TP_UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    TP_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_TenderType",
                columns: table => new
                {
                    TT_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TT_Title = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    TT_CreatedBy = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    TT_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TT_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    TT_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_User_Master",
                columns: table => new
                {
                    usr_sno = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usr_userId = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_pass = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_phone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    usr_usertype = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    use_status = table.Column<int>(nullable: true),
                    usr_createdBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    usr_updatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usr_updatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User_Master", x => x.usr_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserLogin",
                columns: table => new
                {
                    Login_sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login_id = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Login_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Login_UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Login_Password = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Login_Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserLogin", x => x.Login_sno);
                });

            migrationBuilder.CreateTable(
                name: "tbl_VerticalNews",
                columns: table => new
                {
                    VN_Sno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VN_Lang = table.Column<int>(nullable: true),
                    VN_Content = table.Column<int>(nullable: true),
                    VN_Title = table.Column<string>(unicode: false, nullable: true),
                    VN_Description = table.Column<string>(unicode: false, nullable: true),
                    VN_StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VN_EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VN_CreatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VN_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VN_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VN_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    vN_IsArchived = table.Column<bool>(nullable: true),
                    VN_ArchivedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_VideoCategory",
                columns: table => new
                {
                    VC_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VC_Title = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    VC_CreatedBy = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    VC_CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VC_UpdatedBy = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VC_UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_VideoCategory", x => x.VC_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "tbl_AddMenu");

            migrationBuilder.DropTable(
                name: "tbl_Banner");

            migrationBuilder.DropTable(
                name: "tbl_Category");

            migrationBuilder.DropTable(
                name: "tbl_Content");

            migrationBuilder.DropTable(
                name: "tbl_ContentManager");

            migrationBuilder.DropTable(
                name: "tbl_HorizontalNews");

            migrationBuilder.DropTable(
                name: "tbl_Language");

            migrationBuilder.DropTable(
                name: "tbl_linkType");

            migrationBuilder.DropTable(
                name: "tbl_MenuPosition");

            migrationBuilder.DropTable(
                name: "tbl_MenuType");

            migrationBuilder.DropTable(
                name: "tbl_PageName");

            migrationBuilder.DropTable(
                name: "tbl_PhotoCategory");

            migrationBuilder.DropTable(
                name: "tbl_PhotoGallery");

            migrationBuilder.DropTable(
                name: "tbl_PressRelease");

            migrationBuilder.DropTable(
                name: "tbl_Publication");

            migrationBuilder.DropTable(
                name: "tbl_PublicationCategories");

            migrationBuilder.DropTable(
                name: "tbl_PublicationType");

            migrationBuilder.DropTable(
                name: "tbl_PublicAwareness");

            migrationBuilder.DropTable(
                name: "tbl_Status");

            migrationBuilder.DropTable(
                name: "Tbl_Tender");

            migrationBuilder.DropTable(
                name: "tbl_TenderPosition");

            migrationBuilder.DropTable(
                name: "tbl_TenderType");

            migrationBuilder.DropTable(
                name: "tbl_User_Master");

            migrationBuilder.DropTable(
                name: "tbl_UserLogin");

            migrationBuilder.DropTable(
                name: "tbl_VerticalNews");

            migrationBuilder.DropTable(
                name: "tbl_VideoCategory");
        }
    }
}
