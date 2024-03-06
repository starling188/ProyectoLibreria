﻿// <auto-generated />
using System;
using CapaDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CapaDatos.Migrations
{
    [DbContext(typeof(LibreriaTiendaContext))]
    partial class LibreriaTiendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CapaDatos.DataContext.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAutor"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly?>("FechaDefuncion")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nacionalidad")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdAutor")
                        .HasName("PK__Autor__DD33B03189C5CD82");

                    b.ToTable("Autor", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Comentario", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComentario"));

                    b.Property<int?>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("ComentarioText")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("FechaComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdComentario")
                        .HasName("PK__Comentar__DDBEFBF948CA3916");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Comentario", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenero"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdGenero")
                        .HasName("PK__Genero__0F834988163F2BB9");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.HistorialTransaccione", b =>
                {
                    b.Property<int>("IdTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransaccion"));

                    b.Property<DateTime?>("FechaTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("TipoTransaccion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTransaccion")
                        .HasName("PK__Historia__334B1F77D1A09914");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdUsuario");

                    b.ToTable("HistorialTransacciones");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<bool?>("Disponibilidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int?>("IdGenero")
                        .HasColumnType("int");

                    b.Property<string>("PalabrasClave")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sinopsis")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdLibro")
                        .HasName("PK__Libro__3E0B49ADD5B971E6");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdGenero");

                    b.ToTable("Libro", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacion"));

                    b.Property<DateTime?>("FechaEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool?>("Leido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Mensaje")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("IdNotificacion")
                        .HasName("PK__Notifica__F6CA0A8583427E43");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Notificacion", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"));

                    b.Property<string>("EstadoPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Prestado");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo")
                        .HasName("PK__Prestamo__6FF194C03DC3F256");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Prestamo", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<string>("EstadoReserva")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Pendiente");

                    b.Property<DateTime?>("FechaReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdLibro")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdReserva")
                        .HasName("PK__Reserva__0E49C69DC1935427");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdRol")
                        .HasName("PK__Rol__2A49584CC6201878");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Contraseña")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Correo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("RolIdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__5B65BF9799C6DF54");

                    b.HasIndex("RolIdRol");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("CapaDatos.DataContext.Comentario", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Libro", "IdLibroNavigation")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__Comentari__IdLib__628FA481");

                    b.HasOne("CapaDatos.DataContext.Usuario", "IdUsuarioNavigation")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Comentari__IdUsu__619B8048");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.HistorialTransaccione", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Libro", "IdLibroNavigation")
                        .WithMany("HistorialTransacciones")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__Historial__IdLib__6E01572D");

                    b.HasOne("CapaDatos.DataContext.Usuario", "IdUsuarioNavigation")
                        .WithMany("HistorialTransacciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Historial__IdUsu__6D0D32F4");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Libro", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Autor", "IdAutorNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .HasConstraintName("FK__Libro__IdAutor__4D94879B");

                    b.HasOne("CapaDatos.DataContext.Genero", "IdGeneroNavigation")
                        .WithMany("Libros")
                        .HasForeignKey("IdGenero")
                        .HasConstraintName("FK__Libro__IdGenero__4E88ABD4");

                    b.Navigation("IdAutorNavigation");

                    b.Navigation("IdGeneroNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Notificacion", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Usuario", "IdUsuarioNavigation")
                        .WithMany("Notificacions")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Notificac__IdUsu__66603565");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Prestamo", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Libro", "IdLibroNavigation")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__Prestamo__IdLibr__571DF1D5");

                    b.HasOne("CapaDatos.DataContext.Usuario", "IdUsuarioNavigation")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Prestamo__IdUsua__5629CD9C");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Reserva", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Libro", "IdLibroNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("IdLibro")
                        .HasConstraintName("FK__Reserva__IdLibro__5CD6CB2B");

                    b.HasOne("CapaDatos.DataContext.Usuario", "IdUsuarioNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Reserva__IdUsuar__5BE2A6F2");

                    b.Navigation("IdLibroNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Usuario", b =>
                {
                    b.HasOne("CapaDatos.DataContext.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolIdRol");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Genero", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Libro", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("HistorialTransacciones");

                    b.Navigation("Prestamos");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CapaDatos.DataContext.Usuario", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("HistorialTransacciones");

                    b.Navigation("Notificacions");

                    b.Navigation("Prestamos");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
