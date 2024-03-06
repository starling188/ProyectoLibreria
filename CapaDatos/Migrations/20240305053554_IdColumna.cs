using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaDatos.Migrations
{
    /// <inheritdoc />
    public partial class IdColumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Nacionalidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    FechaDefuncion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autor__DD33B03189C5CD82", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genero__0F834988163F2BB9", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__2A49584CC6201878", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    IdAutor = table.Column<int>(type: "int", nullable: true),
                    IdGenero = table.Column<int>(type: "int", nullable: true),
                    PalabrasClave = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Sinopsis = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Libro__3E0B49ADD5B971E6", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK__Libro__IdAutor__4D94879B",
                        column: x => x.IdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor");
                    table.ForeignKey(
                        name: "FK__Libro__IdGenero__4E88ABD4",
                        column: x => x.IdGenero,
                        principalTable: "Genero",
                        principalColumn: "IdGenero");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Correo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    RolIdRol = table.Column<int>(type: "int", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF9799C6DF54", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: true),
                    ComentarioText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Calificacion = table.Column<int>(type: "int", nullable: true),
                    FechaComentario = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__DDBEFBF948CA3916", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK__Comentari__IdLib__628FA481",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK__Comentari__IdUsu__619B8048",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "HistorialTransacciones",
                columns: table => new
                {
                    IdTransaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: true),
                    TipoTransaccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__334B1F77D1A09914", x => x.IdTransaccion);
                    table.ForeignKey(
                        name: "FK__Historial__IdLib__6E01572D",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK__Historial__IdUsu__6D0D32F4",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    IdNotificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Mensaje = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FechaEnvio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Leido = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__F6CA0A8583427E43", x => x.IdNotificacion);
                    table.ForeignKey(
                        name: "FK__Notificac__IdUsu__66603565",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: true),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoPrestamo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Prestado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prestamo__6FF194C03DC3F256", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK__Prestamo__IdLibr__571DF1D5",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK__Prestamo__IdUsua__5629CD9C",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    EstadoReserva = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserva__0E49C69DC1935427", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK__Reserva__IdLibro__5CD6CB2B",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro");
                    table.ForeignKey(
                        name: "FK__Reserva__IdUsuar__5BE2A6F2",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdLibro",
                table: "Comentario",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdUsuario",
                table: "Comentario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTransacciones_IdLibro",
                table: "HistorialTransacciones",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTransacciones_IdUsuario",
                table: "HistorialTransacciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdGenero",
                table: "Libro",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_IdUsuario",
                table: "Notificacion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdLibro",
                table: "Prestamo",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdUsuario",
                table: "Prestamo",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdLibro",
                table: "Reserva",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdUsuario",
                table: "Reserva",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolIdRol",
                table: "Usuario",
                column: "RolIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "HistorialTransacciones");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
