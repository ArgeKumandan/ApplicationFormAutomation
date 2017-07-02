using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ApplicationFormAutomation.WebUI.Models;

namespace ApplicationFormAutomation.WebUI.Migrations
{
    [DbContext(typeof(FormBuilderDbContext))]
    [Migration("20170702184608_GlyphIconCss")]
    partial class GlyphIconCss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText");

                    b.Property<int>("FormElementId");

                    b.Property<int?>("FormSubmitId");

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.HasIndex("FormSubmitId");

                    b.ToTable("FormAnswer");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormAnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormAnswerId");

                    b.Property<int?>("FormElementOptionId");

                    b.HasKey("Id");

                    b.HasIndex("FormAnswerId");

                    b.HasIndex("FormElementOptionId");

                    b.ToTable("FormAnswerOption");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataKey")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<int>("FormElementType");

                    b.Property<int>("FormId");

                    b.Property<int>("FreeTextElemenType");

                    b.Property<string>("GlyphIconCss")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Mask");

                    b.Property<int>("OrderValue");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<bool>("UseMaskForFreeText");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("FormElements");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormElementOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormElementId");

                    b.Property<int>("OrderValue");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FormElementId");

                    b.ToTable("FormElementOption");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormSubmit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("Id");

                    b.ToTable("FormSubmits");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormAnswer", b =>
                {
                    b.HasOne("ApplicationFormAutomation.WebUI.Models.FormElement", "FormElement")
                        .WithMany()
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationFormAutomation.WebUI.Models.FormSubmit", "FormSubmit")
                        .WithMany("FormAnswers")
                        .HasForeignKey("FormSubmitId");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormAnswerOption", b =>
                {
                    b.HasOne("ApplicationFormAutomation.WebUI.Models.FormAnswer", "FormAnswer")
                        .WithMany("FormAnswerOptions")
                        .HasForeignKey("FormAnswerId");

                    b.HasOne("ApplicationFormAutomation.WebUI.Models.FormElementOption", "FormElementOption")
                        .WithMany()
                        .HasForeignKey("FormElementOptionId");
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormElement", b =>
                {
                    b.HasOne("ApplicationFormAutomation.WebUI.Models.Form", "Form")
                        .WithMany("FormElements")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationFormAutomation.WebUI.Models.FormElementOption", b =>
                {
                    b.HasOne("ApplicationFormAutomation.WebUI.Models.FormElement", "FormElement")
                        .WithMany("FormElementOptions")
                        .HasForeignKey("FormElementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
