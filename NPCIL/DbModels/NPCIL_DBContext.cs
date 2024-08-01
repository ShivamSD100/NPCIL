using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NPCIL.DbModels
{
    public partial class NPCIL_DBContext : DbContext
    {
        public NPCIL_DBContext()
        {
        }

        public NPCIL_DBContext(DbContextOptions<NPCIL_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PageDataBind> PageDataBinds { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<TblAddMenu> TblAddMenu { get; set; }
        public virtual DbSet<TblBanner> TblBanner { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblContent> TblContent { get; set; }
        public virtual DbSet<TblContentManager> TblContentManager { get; set; }
        public virtual DbSet<TblHorizontalNews> TblHorizontalNews { get; set; }
        public virtual DbSet<TblLanguage> TblLanguage { get; set; }
        public virtual DbSet<TblLinkType> TblLinkType { get; set; }
        public virtual DbSet<TblMenuPosition> TblMenuPosition { get; set; }
        public virtual DbSet<TblMenuType> TblMenuType { get; set; }
        public virtual DbSet<TblPageName> TblPageName { get; set; }
        public virtual DbSet<TblPhotoCategory> TblPhotoCategory { get; set; }
        public virtual DbSet<TblPhotoGallery> TblPhotoGallery { get; set; }
        public virtual DbSet<TblPressRelease> TblPressRelease { get; set; }
        public virtual DbSet<TblPublicAwareness> TblPublicAwareness { get; set; }
        public virtual DbSet<TblPublication> TblPublication { get; set; }
        public virtual DbSet<TblPublicationCategories> TblPublicationCategories { get; set; }
        public virtual DbSet<TblPublicationType> TblPublicationType { get; set; }
        public virtual DbSet<TblStatus> TblStatus { get; set; }
        public virtual DbSet<TblTender> TblTender { get; set; }
        public virtual DbSet<TblTenderPosition> TblTenderPosition { get; set; }
        public virtual DbSet<TblTenderType> TblTenderType { get; set; }
        public virtual DbSet<TblUserLogin> TblUserLogin { get; set; }
        public virtual DbSet<TblUserMaster> TblUserMaster { get; set; }
        public virtual DbSet<TblVerticalNews> TblVerticalNews { get; set; }
        public virtual DbSet<TblVideoCategory> TblVideoCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=173.249.52.210,7160;Database=NPCIL_DB;User Id=sa;Password=Jabit_7160;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Logs__5E5486486551B04B");

                entity.Property(e => e.ExceptionMessage).IsUnicode(false);

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogMessage).IsUnicode(false);

                entity.Property(e => e.StackTrace).IsUnicode(false);
            });



            modelBuilder.Entity<TblAddMenu>(entity =>
            {
                entity.HasKey(e => e.MenuSno);

                entity.ToTable("tbl_AddMenu");

                entity.Property(e => e.MenuSno).HasColumnName("menu_sno");

                entity.Property(e => e.ContentEng)
                    .HasColumnName("content_eng")
                    .IsUnicode(false);

                entity.Property(e => e.ContentHind).HasColumnName("Content_hind");

                entity.Property(e => e.DataListBind).IsUnicode(false);

                entity.Property(e => e.Eventyear)
                    .HasColumnName("eventyear")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileEnddate)
                    .HasColumnName("file_Enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileImage)
                    .HasColumnName("file_image")
                    .IsUnicode(false);

                entity.Property(e => e.FileStartdate)
                    .HasColumnName("file_Startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinkType).HasColumnName("linkType");

                entity.Property(e => e.LinkUrlname)
                    .HasColumnName("link_urlname")
                    .IsUnicode(false);

                entity.Property(e => e.MenuCreatedby)
                    .HasColumnName("menu_createdby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuCreateddate)
                    .HasColumnName("menu_createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MenuDescEng)
                    .HasColumnName("menu_desc_eng")
                    .IsUnicode(false);

                entity.Property(e => e.MenuDescHind).HasColumnName("menu_desc_hind");

                entity.Property(e => e.MenuImg)
                    .HasColumnName("menu_img")
                    .IsUnicode(false);

                entity.Property(e => e.MenuNameEng)
                    .HasColumnName("menu_name_eng")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MenuNameHind).HasColumnName("menu_name_hind");

                entity.Property(e => e.MenuOrder).HasColumnName("menuOrder");

                entity.Property(e => e.MenuPosition).HasColumnName("menu_position");

                entity.Property(e => e.MenuType).HasColumnName("menu_type");

                entity.Property(e => e.MenuUpdatedby)
                    .HasColumnName("menu_updatedby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuUpdateddate)
                    .HasColumnName("menu_updateddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TabActive).HasColumnName("tab_active");
            });

            modelBuilder.Entity<TblBanner>(entity =>
            {
                entity.HasKey(e => e.BanSno);

                entity.ToTable("tbl_Banner");

                entity.Property(e => e.BanSno).HasColumnName("ban_sno");

                entity.Property(e => e.BanAltTag)
                    .HasColumnName("ban_altTag")
                    .IsUnicode(false);

                entity.Property(e => e.BanAltTagLang).HasColumnName("ban_altTagLang");

                entity.Property(e => e.BanCreatedBy)
                    .HasColumnName("ban_createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanCreatedDate)
                    .HasColumnName("ban_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BanLinkUrl)
                    .HasColumnName("ban_linkURL")
                    .IsUnicode(false);

                entity.Property(e => e.BanTitle)
                    .HasColumnName("ban_title")
                    .IsUnicode(false);

                entity.Property(e => e.BanTitleLang).HasColumnName("ban_titleLang");

                entity.Property(e => e.BanUpdatedBy)
                    .HasColumnName("ban_updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanUpdatedDate)
                    .HasColumnName("ban_updatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BanUploadImg)
                    .HasColumnName("ban_uploadImg")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CtSno);

                entity.ToTable("tbl_Category");

                entity.Property(e => e.CtSno).HasColumnName("ct_sno");

                entity.Property(e => e.CtCreatedBy)
                    .HasColumnName("ct_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CtCreatedDate)
                    .HasColumnName("ct_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CtName)
                    .HasColumnName("ct_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CtUpdateDate)
                    .HasColumnName("ct_updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CtUpdatedBy)
                    .HasColumnName("ct_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblContent>(entity =>
            {
                entity.HasKey(e => e.ConSno);

                entity.ToTable("tbl_Content");

                entity.Property(e => e.ConSno).HasColumnName("con_sno");

                entity.Property(e => e.ConCreatedBy)
                    .HasColumnName("con_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConCreatedDate)
                    .HasColumnName("con_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConName)
                    .HasColumnName("con_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConUpdatedBy)
                    .HasColumnName("con_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConUpdatedDate)
                    .HasColumnName("con_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblContentManager>(entity =>
            {
                entity.HasKey(e => e.CmSno);

                entity.ToTable("tbl_ContentManager");

                entity.Property(e => e.CmSno).HasColumnName("CM_Sno");

                entity.Property(e => e.CmCreatedby)
                    .HasColumnName("CM_createdby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmCreateddate)
                    .HasColumnName("CM_createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CmEnddate)
                    .HasColumnName("CM_enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CmImage)
                    .HasColumnName("CM_image")
                    .IsUnicode(false);

                entity.Property(e => e.CmNameEng)
                    .HasColumnName("CM_name_eng")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmNameHind).HasColumnName("CM_name_hind");

                entity.Property(e => e.CmPageContentEng)
                    .HasColumnName("CM_PageContent_eng")
                    .IsUnicode(false);

                entity.Property(e => e.CmPageContentHind).HasColumnName("CM_PageContent_hind");

                entity.Property(e => e.CmPosition).HasColumnName("CM_position");

                entity.Property(e => e.CmShortDescEng)
                    .HasColumnName("CM_shortDescEng")
                    .IsUnicode(false);

                entity.Property(e => e.CmShortDescHind).HasColumnName("CM_shortDescHind");

                entity.Property(e => e.CmStartdate)
                    .HasColumnName("CM_startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CmType).HasColumnName("CM_type");

                entity.Property(e => e.CmUpdatedby)
                    .HasColumnName("CM_updatedby")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmUpdateddate)
                    .HasColumnName("CM_updateddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MenuId).HasColumnName("Menu_Id");
            });

            modelBuilder.Entity<TblHorizontalNews>(entity =>
            {
                entity.HasKey(e => e.HnSno);

                entity.ToTable("tbl_HorizontalNews");

                entity.Property(e => e.HnSno).HasColumnName("HN_Sno");

                entity.Property(e => e.HnArchivedDate)
                    .HasColumnName("HN_ArchivedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HnContent).HasColumnName("HN_Content");

                entity.Property(e => e.HnCreatedBy)
                    .HasColumnName("HN_CreatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HnCreatedDate)
                    .HasColumnName("HN_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HnDescription)
                    .HasColumnName("HN_Description")
                    .IsUnicode(false);

                entity.Property(e => e.HnEndDate)
                    .HasColumnName("HN_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HnIsArchived).HasColumnName("HN_IsArchived");

                entity.Property(e => e.HnLang).HasColumnName("HN_Lang");

                entity.Property(e => e.HnStartDate)
                    .HasColumnName("HN_StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HnTitle)
                    .HasColumnName("HN_Title")
                    .IsUnicode(false);

                entity.Property(e => e.HnUpdatedBy)
                    .HasColumnName("HN_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HnUpdatedDate)
                    .HasColumnName("HN_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLanguage>(entity =>
            {
                entity.HasKey(e => e.LangSno);

                entity.ToTable("tbl_Language");

                entity.Property(e => e.LangSno).HasColumnName("lang_sno");

                entity.Property(e => e.LangCreatedBy)
                    .HasColumnName("lang_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LangCreatedDate)
                    .HasColumnName("lang_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LangName)
                    .HasColumnName("lang_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LangUpdatedBy)
                    .HasColumnName("lang_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LangUpdatedDate)
                    .HasColumnName("lang_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLinkType>(entity =>
            {
                entity.HasKey(e => e.LinkId);

                entity.ToTable("tbl_linkType");

                entity.Property(e => e.LinkId).HasColumnName("link_id");

                entity.Property(e => e.LinkName)
                    .HasColumnName("link_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMenuPosition>(entity =>
            {
                entity.HasKey(e => e.MpSno);

                entity.ToTable("tbl_MenuPosition");

                entity.Property(e => e.MpSno).HasColumnName("mp_sno");

                entity.Property(e => e.MpCreatedBy)
                    .HasColumnName("mp_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MpCreatedDate)
                    .HasColumnName("mp_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpName)
                    .HasColumnName("mp_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MpUpdatedBy)
                    .HasColumnName("mp_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MpUpdatedDate)
                    .HasColumnName("mp_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMenuType>(entity =>
            {
                entity.HasKey(e => e.MtSno);

                entity.ToTable("tbl_MenuType");

                entity.Property(e => e.MtSno).HasColumnName("mt_sno");

                entity.Property(e => e.MtCreatedBy)
                    .HasColumnName("mt_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MtCreatedDate)
                    .HasColumnName("mt_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MtName)
                    .HasColumnName("mt_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MtUpdatedBy)
                    .HasColumnName("mt_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MtUpdatedDate)
                    .HasColumnName("mt_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPageName>(entity =>
            {
                entity.HasKey(e => e.PgnSno);

                entity.ToTable("tbl_PageName");

                entity.Property(e => e.PgnSno).HasColumnName("pgn_sno");

                entity.Property(e => e.PgnCreatedBy)
                    .HasColumnName("pgn_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PgnCreatedDate)
                    .HasColumnName("pgn_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PgnName)
                    .HasColumnName("pgn_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PgnUpdatedBy)
                    .HasColumnName("pgn_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PgnUpdatedDate)
                    .HasColumnName("pgn_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPhotoCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_PhotoCategory");

                entity.Property(e => e.PhCCreatedBy)
                    .HasColumnName("PhC_CreatedBy")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhCCreatedDate)
                    .HasColumnName("PhC_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhCId)
                    .HasColumnName("PhC_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PhCTitle)
                    .HasColumnName("PhC_Title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhCUpdatedBy)
                    .HasColumnName("PhC_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhCUpdatedDate)
                    .HasColumnName("PhC_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPhotoGallery>(entity =>
            {
                entity.HasKey(e => e.PhSno);

                entity.ToTable("tbl_PhotoGallery");

                entity.Property(e => e.PhSno).HasColumnName("Ph_sno");

                entity.Property(e => e.PhCategory).HasColumnName("Ph_category");

                entity.Property(e => e.PhCreatedBy)
                    .HasColumnName("Ph_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhCreatedDate)
                    .HasColumnName("Ph_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhDescription)
                    .HasColumnName("Ph_description")
                    .IsUnicode(false);

                entity.Property(e => e.PhDescriptionReg)
                    .HasColumnName("Ph_description_reg")
                    .IsUnicode(false);

                entity.Property(e => e.PhImage)
                    .HasColumnName("Ph_image")
                    .IsUnicode(false);

                entity.Property(e => e.PhTag)
                    .HasColumnName("Ph_tag")
                    .IsUnicode(false);

                entity.Property(e => e.PhTagReg)
                    .HasColumnName("Ph_tag_reg")
                    .IsUnicode(false);

                entity.Property(e => e.PhTitle)
                    .HasColumnName("Ph_title")
                    .IsUnicode(false);

                entity.Property(e => e.PhTitleReg)
                    .HasColumnName("Ph_title_reg")
                    .IsUnicode(false);

                entity.Property(e => e.PhUpdatedBy)
                    .HasColumnName("Ph_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhUpdatedDate)
                    .HasColumnName("Ph_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPressRelease>(entity =>
            {
                entity.HasKey(e => e.PrSno);

                entity.ToTable("tbl_PressRelease");

                entity.Property(e => e.PrSno).HasColumnName("PR_sno");

                entity.Property(e => e.PrContent).HasColumnName("PR_Content");

                entity.Property(e => e.PrCreatedBy)
                    .HasColumnName("PR_CreatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrCreatedDate)
                    .HasColumnName("PR_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrEndDate)
                    .HasColumnName("PR_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrFileUpload).HasColumnName("PR_FileUpload");

                entity.Property(e => e.PrLanguage).HasColumnName("PR_Language");

                entity.Property(e => e.PrLinkUrl).HasColumnName("PR_LinkURL");

                entity.Property(e => e.PrPageDescription).HasColumnName("PR_PageDescription");

                entity.Property(e => e.PrStartDate)
                    .HasColumnName("PR_StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrTitle).HasColumnName("PR_Title");

                entity.Property(e => e.PrUpdatedBy)
                    .HasColumnName("PR_UpdatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrUpdatedDate)
                    .HasColumnName("PR_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPublicAwareness>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_PublicAwareness");

                entity.Property(e => e.PaContent).HasColumnName("PA_Content");

                entity.Property(e => e.PaCreatedBy)
                    .HasColumnName("PA_CreatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaCreatedDate)
                    .HasColumnName("PA_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaEndDate)
                    .HasColumnName("PA_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaFileUpload).HasColumnName("PA_FileUpload");

                entity.Property(e => e.PaLanguage).HasColumnName("PA_Language");

                entity.Property(e => e.PaLinkUrl).HasColumnName("PA_LinkURL");

                entity.Property(e => e.PaPageDescription).HasColumnName("PA_PageDescription");

                entity.Property(e => e.PaSno)
                    .HasColumnName("PA_sno")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PaStartDate)
                    .HasColumnName("PA_StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaTitle).HasColumnName("PA_Title");

                entity.Property(e => e.PaUpdatedBy)
                    .HasColumnName("PA_UpdatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaUpdatedDate)
                    .HasColumnName("PA_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPublication>(entity =>
            {
                entity.HasKey(e => e.PubId);

                entity.ToTable("tbl_Publication");

                entity.Property(e => e.PubId).HasColumnName("Pub_id");

                entity.Property(e => e.PubAuthorName)
                    .HasColumnName("Pub_AuthorName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PubCreatedBy)
                    .HasColumnName("Pub_CreatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PubCreatedDate)
                    .HasColumnName("Pub_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PubFileUpload)
                    .HasColumnName("Pub_FileUpload")
                    .IsUnicode(false);

                entity.Property(e => e.PubLanguage).HasColumnName("Pub_Language");

                entity.Property(e => e.PubOthers)
                    .HasColumnName("Pub_Others")
                    .IsUnicode(false);

                entity.Property(e => e.PubTitle)
                    .HasColumnName("Pub_Title")
                    .IsUnicode(false);

                entity.Property(e => e.PubType).HasColumnName("Pub_Type");

                entity.Property(e => e.PubUpdatedBy)
                    .HasColumnName("Pub_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PubUpdatedDate)
                    .HasColumnName("Pub_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPublicationCategories>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_PublicationCategories");

                entity.Property(e => e.PcAltTag)
                    .HasColumnName("PC_altTag")
                    .IsUnicode(false);

                entity.Property(e => e.PcAltTagLang).HasColumnName("PC_altTagLang");

                entity.Property(e => e.PcCreatedBy)
                    .HasColumnName("PC_createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcCreatedDate)
                    .HasColumnName("PC_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcLinkUrl)
                    .HasColumnName("PC_linkURL")
                    .IsUnicode(false);

                entity.Property(e => e.PcSno)
                    .HasColumnName("PC_sno")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PcTitle)
                    .HasColumnName("PC_title")
                    .IsUnicode(false);

                entity.Property(e => e.PcTitleLang).HasColumnName("PC_titleLang");

                entity.Property(e => e.PcUpdatedBy)
                    .HasColumnName("PC_updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PcUpdatedDate)
                    .HasColumnName("PC_updatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcUploadImg)
                    .HasColumnName("PC_uploadImg")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPublicationType>(entity =>
            {
                entity.HasKey(e => e.PtSno);

                entity.ToTable("tbl_PublicationType");

                entity.Property(e => e.PtSno).HasColumnName("pt_sno");

                entity.Property(e => e.PtCreatedBy)
                    .HasColumnName("pt_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PtCreatedDate)
                    .HasColumnName("pt_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PtName)
                    .HasColumnName("pt_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PtUpdatedBy)
                    .HasColumnName("pt_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PtUpdatedDate)
                    .HasColumnName("pt_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblStatus>(entity =>
            {
                entity.HasKey(e => e.StSno);

                entity.ToTable("tbl_Status");

                entity.Property(e => e.StSno).HasColumnName("st_sno");

                entity.Property(e => e.StCreatedBy)
                    .HasColumnName("st_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StCreatedDate)
                    .HasColumnName("st_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StName)
                    .HasColumnName("st_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StUpdatedBy)
                    .HasColumnName("st_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StUpdatedDate)
                    .HasColumnName("st_updatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTender>(entity =>
            {
                entity.HasKey(e => e.TenderId);

                entity.ToTable("Tbl_Tender");

                entity.Property(e => e.TenderId).HasColumnName("Tender_id");

                entity.Property(e => e.TenderArchivedDate)
                    .HasColumnName("Tender_archived_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderBodyEng)
                    .HasColumnName("Tender_body_eng")
                    .IsUnicode(false);

                entity.Property(e => e.TenderBodyHindi).HasColumnName("Tender_body_hindi");

                entity.Property(e => e.TenderCost)
                    .HasColumnName("Tender_cost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenderCreatedDate)
                    .HasColumnName("Tender_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderCreatedby)
                    .HasColumnName("Tender_Createdby")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenderDateOpening)
                    .HasColumnName("Tender_DateOpening")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderEmd)
                    .HasColumnName("Tender_EMD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenderEndDateReceivingTender)
                    .HasColumnName("Tender_EndDate_ReceivingTender")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderEndDateSellingTender)
                    .HasColumnName("Tender_EndDate_SellingTender")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderIsArchived).HasColumnName("Tender_IsArchived");

                entity.Property(e => e.TenderMarkImportant).HasColumnName("Tender_markImportant");

                entity.Property(e => e.TenderPrebidDate)
                    .HasColumnName("Tender_Prebid_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderScopeEng)
                    .HasColumnName("Tender_Scope_eng")
                    .IsUnicode(false);

                entity.Property(e => e.TenderScopeHindi).HasColumnName("Tender_Scope_hindi");

                entity.Property(e => e.TenderStartDateReceivingTender)
                    .HasColumnName("Tender_StartDate_ReceivingTender")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderStartDateSellingTender)
                    .HasColumnName("Tender_StartDate_SellingTender")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderUpdatedBy)
                    .HasColumnName("Tender_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenderUpdatedDate)
                    .HasColumnName("Tender_UpdatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TenderUpload)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TenderUrl)
                    .HasColumnName("TenderURL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TendorIssuingAuthEng)
                    .HasColumnName("Tendor_IssuingAuth_eng")
                    .IsUnicode(false);

                entity.Property(e => e.TendorIssuingAuthHindi).HasColumnName("Tendor_IssuingAuth_hindi");

                entity.Property(e => e.TendorNo)
                    .HasColumnName("Tendor_no")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTenderPosition>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_TenderPosition");

                entity.Property(e => e.TpCreatedBy)
                    .HasColumnName("TP_CreatedBy")
                    .HasMaxLength(200);

                entity.Property(e => e.TpCreatedDate)
                    .HasColumnName("TP_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TpId)
                    .HasColumnName("TP_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TpTitle)
                    .HasColumnName("TP_Title")
                    .HasMaxLength(200);

                entity.Property(e => e.TpUpdatedBy)
                    .HasColumnName("TP_UpdatedBy")
                    .HasMaxLength(100);

                entity.Property(e => e.TpUpdatedDate)
                    .HasColumnName("TP_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTenderType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_TenderType");

                entity.Property(e => e.TtCreatedBy)
                    .HasColumnName("TT_CreatedBy")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TtCreatedDate)
                    .HasColumnName("TT_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TtId)
                    .HasColumnName("TT_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TtTitle)
                    .HasColumnName("TT_Title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TtUpdatedBy)
                    .HasColumnName("TT_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TtUpdatedDate)
                    .HasColumnName("TT_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginSno);

                entity.ToTable("tbl_UserLogin");

                entity.Property(e => e.LoginSno).HasColumnName("Login_sno");

                entity.Property(e => e.LoginId)
                    .HasColumnName("Login_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginName)
                    .HasColumnName("Login_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .HasColumnName("Login_Password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginStatus).HasColumnName("Login_Status");

                entity.Property(e => e.LoginUserName)
                    .HasColumnName("Login_UserName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserMaster>(entity =>
            {
                entity.HasKey(e => e.UsrSno);

                entity.ToTable("tbl_User_Master");

                entity.Property(e => e.UsrSno).HasColumnName("usr_sno");

                entity.Property(e => e.UseStatus).HasColumnName("use_status");

                entity.Property(e => e.UsrCreatedBy)
                    .HasColumnName("usr_createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrCreatedDate)
                    .HasColumnName("usr_createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrEmail)
                    .HasColumnName("usr_email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrName)
                    .HasColumnName("usr_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrPass)
                    .HasColumnName("usr_pass")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrPhone)
                    .HasColumnName("usr_phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUpdatedBy)
                    .HasColumnName("usr_updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUpdatedDate)
                    .HasColumnName("usr_updatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsrUserId)
                    .HasColumnName("usr_userId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUsertype)
                    .HasColumnName("usr_usertype")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVerticalNews>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_VerticalNews");

                entity.Property(e => e.VNIsArchived).HasColumnName("vN_IsArchived");

                entity.Property(e => e.VnArchivedDate)
                    .HasColumnName("VN_ArchivedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VnContent).HasColumnName("VN_Content");

                entity.Property(e => e.VnCreatedBy)
                    .HasColumnName("VN_CreatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VnCreatedDate)
                    .HasColumnName("VN_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VnDescription)
                    .HasColumnName("VN_Description")
                    .IsUnicode(false);

                entity.Property(e => e.VnEndDate)
                    .HasColumnName("VN_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VnLang).HasColumnName("VN_Lang");

                entity.Property(e => e.VnSno)
                    .HasColumnName("VN_Sno")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VnStartDate)
                    .HasColumnName("VN_StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VnTitle)
                    .HasColumnName("VN_Title")
                    .IsUnicode(false);

                entity.Property(e => e.VnUpdatedBy)
                    .HasColumnName("VN_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VnUpdatedDate)
                    .HasColumnName("VN_UpdatedDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblVideoCategory>(entity =>
            {
                entity.HasKey(e => e.VcId);

                entity.ToTable("tbl_VideoCategory");

                entity.Property(e => e.VcId).HasColumnName("VC_id");

                entity.Property(e => e.VcCreatedBy)
                    .HasColumnName("VC_CreatedBy")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VcCreatedDate)
                    .HasColumnName("VC_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VcTitle)
                    .HasColumnName("VC_Title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VcUpdatedBy)
                    .HasColumnName("VC_UpdatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VcUpdatedDate)
                    .HasColumnName("VC_UpdatedDate")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
