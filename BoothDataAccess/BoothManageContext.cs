using System;
using BoothModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IBoothDataAccess;

namespace BoothDataAccess
{
    public partial class BoothManageContext : DbContext,IBoothManageContext
    {
        public BoothManageContext()
        {
        }

        public BoothManageContext(DbContextOptions<BoothManageContext> options)
            : base(options)
        {
        }
        public override int SaveChanges()
        {
            return base.SaveChanges(true);
        }


        public virtual DbSet<BooAucalnfo> BooAucalnfo { get; set; }
        public virtual DbSet<BooInfo> BooInfo { get; set; }
        public virtual DbSet<ConTastInfo> ConTastInfo { get; set; }
        public virtual DbSet<MarketInfo> MarketInfo { get; set; }
        public virtual DbSet<MemberInfoo> MemberInfoo { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<RbacAdmin> RbacAdmin { get; set; }
        public virtual DbSet<RbacDeptPart> RbacDeptPart { get; set; }
        public virtual DbSet<RbacPower> RbacPower { get; set; }
        public virtual DbSet<RbacPowerAndRole> RbacPowerAndRole { get; set; }
        public virtual DbSet<RbacRoleInfo> RbacRoleInfo { get; set; }
        public virtual DbSet<RecordInfo> RecordInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=BoothManage;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooAucalnfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("摊位竞拍Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BooAucaState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("状态");

                entity.Property(e => e.BooId).HasComment("摊位Id");

                entity.Property(e => e.CashMoney)
                    .HasColumnType("money")
                    .HasComment("保证金");

                entity.Property(e => e.CashMoneyState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("保证金");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("开始时间");

                entity.Property(e => e.DefTime)
                    .HasColumnType("datetime")
                    .HasComment("延迟周期");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.FinishPrice)
                    .HasColumnType("money")
                    .HasComment("成交价格");

                entity.Property(e => e.MarkUpMoney)
                    .HasColumnType("money")
                    .HasComment("加价幅度");

                entity.Property(e => e.OrderState)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasComment("订单");

                entity.Property(e => e.ResMoney)
                    .HasColumnType("money")
                    .HasComment("保留价");

                entity.Property(e => e.StartMoney)
                    .HasColumnType("money")
                    .HasComment("起拍价");

                entity.Property(e => e.WinnerUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("中标用户");
            });

            modelBuilder.Entity<BooInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BooArea).HasColumnName("Boo_Area");

                entity.Property(e => e.BooDead).HasColumnName("Boo_Dead");

                entity.Property(e => e.BooLabel)
                    .HasColumnName("Boo_Label")
                    .HasMaxLength(50);

                entity.Property(e => e.BooLen).HasColumnName("Boo_Len");

                entity.Property(e => e.BooNo)
                    .HasColumnName("Boo_No")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BooRent)
                    .HasColumnName("Boo_Rent")
                    .HasColumnType("money");

                entity.Property(e => e.BooTitle)
                    .HasColumnName("Boo_Title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BooWid).HasColumnName("Boo_Wid");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnable)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LessId).HasColumnName("Less_Id(租户Id)");

                entity.Property(e => e.MarkId).HasColumnName("Mark_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConTastInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("合同Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("合同编号");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("上传时间");

                entity.Property(e => e.Oid)
                    .HasColumnName("OId")
                    .HasComment("订单列表Id");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");
            });

            modelBuilder.Entity<MarketInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnable)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MarkAccName)
                    .HasColumnName("Mark_AccName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarkAddress)
                    .HasColumnName("Mark_Address")
                    .IsUnicode(false);

                entity.Property(e => e.MarkName)
                    .HasColumnName("Mark_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarkPhone)
                    .HasColumnName("Mark_Phone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.MarkSortId).HasColumnName("Mark_SortId");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberInfoo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("会员Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsAllow)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("是否允许访问");

                entity.Property(e => e.MemAddress)
                    .HasColumnName("Mem_Address")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("会员地址");

                entity.Property(e => e.MemName)
                    .HasColumnName("Mem_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("会员名称");

                entity.Property(e => e.MemState)
                    .HasColumnName("Mem_State")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("状态");

                entity.Property(e => e.MemWx)
                    .HasColumnName("Mem_WX")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("微信账号");
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BooAucaId).HasComment("摊位竞拍Id");

                entity.Property(e => e.CashMoney)
                    .HasColumnType("money")
                    .HasComment("保证金");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("订单号");

                entity.Property(e => e.OrderState)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PayState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("付款状态");

                entity.Property(e => e.RenPrice)
                    .HasColumnType("money")
                    .HasComment("租赁金额");

                entity.Property(e => e.Teancy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("租期");

                entity.Property(e => e.UserId).HasComment("租户Id");
            });

            modelBuilder.Entity<RbacAdmin>(entity =>
            {
                entity.ToTable("Rbac_Admin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccImg)
                    .HasColumnName("Acc_Img")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AccName)
                    .HasColumnName("Acc_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccNum)
                    .HasColumnName("Acc_Num")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccPass)
                    .HasColumnName("Acc_Pass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccPhone)
                    .HasColumnName("Acc_Phone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnable)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RbacDeptPart>(entity =>
            {
                entity.ToTable("Rbac_DeptPart");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeptDesc)
                    .HasColumnName("Dept_Desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeptName)
                    .HasColumnName("Dept_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnable)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RbacPower>(entity =>
            {
                entity.ToTable("Rbac_Power");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PowerName)
                    .HasColumnName("Power_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RbacPowerAndRole>(entity =>
            {
                entity.ToTable("Rbac_PowerAndRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PowerId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RbacRoleInfo>(entity =>
            {
                entity.ToTable("Rbac_RoleInfo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnable)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RoleDesc)
                    .HasColumnName("Role_Desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RecordInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IpAddress)
                    .HasColumnName("Ip_Address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Record)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MemerId).HasComment("关联会员");

                entity.Property(e => e.UserAddress)
                    .HasColumnName("User_Address")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("联系地址");

                entity.Property(e => e.UserImg)
                    .HasColumnName("User_Img")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("头像");

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("租户名称");

                entity.Property(e => e.UserPass)
                    .HasColumnName("User_Pass")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("租户密码");

                entity.Property(e => e.UserPhone)
                    .HasColumnName("User_Phone")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("联系方式");

                entity.Property(e => e.UserState)
                    .HasColumnName("User_State")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("状态");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
