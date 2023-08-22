﻿// <auto-generated />
using DemoWebApiProject.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoWebApiProject.Migrations
{
    [DbContext(typeof(GameProgressContext))]
    [Migration("20230822002105_SeedingTheSampleData")]
    partial class SeedingTheSampleData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("DemoWebApiProject.Entities.GameProgress", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChineseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnglishName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId");

                    b.ToTable("GameProgresses");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            ChineseName = "心灵终结",
                            Description = "红警2最好的资料片没有之一。单线剧情完整严谨，兵种与剧情挂钩。高难度下的关卡有焕然一新的设计。科技树与种族特性相结合。多达四个族都有完整战役，而且还有额外战役，联机合作战役等。模式极其丰富",
                            EnglishName = "Mental Omega",
                            Name = "心灵终结 Mental Omega",
                            Year = 2022
                        },
                        new
                        {
                            GameId = 2,
                            ChineseName = "折磨之魂",
                            Description = "很优秀的老生化型作品",
                            Name = "tormented souls",
                            Year = 2022
                        },
                        new
                        {
                            GameId = 3,
                            ChineseName = "暗黑破坏神2重制版",
                            Description = "童年经典的完美重现\n而且现在还在更新平衡性补丁以及新内容",
                            Name = "暗黑破坏神2重制版 D2R",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("DemoWebApiProject.Entities.GameProgressOnPlatform", b =>
                {
                    b.Property<int>("GameProgressOnThisPlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BugsAndIssues")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProgressOnThisPlatform")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecommendedMouseSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameProgressOnThisPlatformId");

                    b.HasIndex("GameId");

                    b.ToTable("GameProgressOnPlatforms");

                    b.HasData(
                        new
                        {
                            GameProgressOnThisPlatformId = 1,
                            GameId = 2,
                            Platform = "PC",
                            ProgressOnThisPlatform = "修改器修改了存档磁带数量通关，在游戏末期才入手隐藏武器",
                            RecommendedMouseSpeed = "Undecided mouse speed"
                        },
                        new
                        {
                            GameProgressOnThisPlatformId = 2,
                            BugsAndIssues = "坑爹的暴雪大幅下调了暴率",
                            GameId = 3,
                            Platform = "PC",
                            ProgressOnThisPlatform = "联机模式下七职业慢慢交易以及慢慢刷\r\n单机模式下普通模式正在打造最强配置，硬核模式下考虑导入极品黄以及老版本暗金进行娱乐",
                            RecommendedMouseSpeed = "Undecided mouse speed"
                        });
                });

            modelBuilder.Entity("DemoWebApiProject.Entities.GameProgressOnPlatform", b =>
                {
                    b.HasOne("DemoWebApiProject.Entities.GameProgress", "GameProgress")
                        .WithMany("GameProgressOnPlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameProgress");
                });

            modelBuilder.Entity("DemoWebApiProject.Entities.GameProgress", b =>
                {
                    b.Navigation("GameProgressOnPlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}
