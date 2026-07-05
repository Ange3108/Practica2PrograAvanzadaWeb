(() => {

    const Categoria = {

        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },

        inicializarTabla() {

            this.tabla = $('#tblCategoria').DataTable({

                ajax: {
                    url: '/Categoria/GetCategorias',
                    type: 'GET',
                    dataSrc: 'dato'
                },

                columns: [

                    { data: 'idCategoria' },

                    { data: 'nombre' },

                    { data: 'descripcion' },

                    {
                        data: null,
                        title: 'Acciones',
                        orderable: false,
                        render: (data, type, row) => {

                            return `
                                <button class="btn btn-sm btn-primary btn-editar"
                                        data-id="${row.idCategoria}">
                                    Editar
                                </button>

                                <button class="btn btn-sm btn-danger btn-eliminar"
                                        data-id="${row.idCategoria}">
                                    Eliminar
                                </button>
                            `;
                        }
                    }
                ],

                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                }

            });

        },

        registrarEventos() {

            $('#tblCategoria').on('click', '.btn-editar', function () {

                const id = $(this).data('id');

                Categoria.cargarCategoria(id);

            });

            $('#tblCategoria').on('click', '.btn-eliminar', function () {

                const id = $(this).data('id');

                Categoria.eliminarCategoria(id);

            });

            $('#btnGuardarCategoria').on('click', function () {

                Categoria.guardarCategoria();

            });

            $('#btnEditarCategoria').on('click', function () {

                Categoria.editarCategoria();

            });

        },

        guardarCategoria() {

            let form = $('#formCrearCategoria');

            if (!form.valid()) {
                return;
            }

            $.ajax({

                url: '/Categoria/CreateCategoria',
                type: 'POST',
                data: form.serialize(),

                success: function (respuesta) {

                    if (respuesta.esCorrecto) {

                        $('#modalCrearCategoria').modal('hide');

                        form[0].reset();

                        Categoria.tabla.ajax.reload();

                        Swal.fire({
                            title: 'Correcto',
                            text: respuesta.mensaje,
                            icon: 'success'
                        });

                    } else {

                        Swal.fire({
                            title: 'Error',
                            text: respuesta.mensaje,
                            icon: 'error'
                        });

                    }

                }

            });

        },

        editarCategoria() {

            let form = $('#formEditarCategoria');

            if (!form.valid()) {
                return;
            }

            $.ajax({

                url: '/Categoria/UpdateCategoria',
                type: 'POST',
                data: form.serialize(),

                success: function (respuesta) {

                    if (respuesta.esCorrecto) {

                        $('#modalEditarCategoria').modal('hide');

                        form[0].reset();

                        Categoria.tabla.ajax.reload();

                        Swal.fire({
                            title: 'Correcto',
                            text: respuesta.mensaje,
                            icon: 'success'
                        });

                    } else {

                        Swal.fire({
                            title: 'Error',
                            text: respuesta.mensaje,
                            icon: 'error'
                        });

                    }

                }

            });

        },

        eliminarCategoria(id) {

            Swal.fire({

                title: '¿Está seguro?',
                text: 'No podrá revertir esta operación',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí, eliminar'

            }).then((result) => {

                if (result.isConfirmed) {

                    $.ajax({

                        url: `/Categoria/DeleteCategoria?id=${id}`,
                        type: 'DELETE',

                        success: function (respuesta) {

                            if (respuesta.esCorrecto) {

                                Categoria.tabla.ajax.reload();

                                Swal.fire({
                                    title: 'Correcto',
                                    text: respuesta.mensaje,
                                    icon: 'success'
                                });

                            } else {

                                Swal.fire({
                                    title: 'Error',
                                    text: respuesta.mensaje,
                                    icon: 'error'
                                });

                            }

                        },

                        error: function () {

                            Swal.fire({
                                title: 'Error',
                                text: 'Ocurrió un error al eliminar la categoría',
                                icon: 'error'
                            });

                        }

                    });

                }

            });

        },

        cargarCategoria(id) {

            $.get(

                `/Categoria/GetCategoriaById?id=${id}`,

                function (resultado) {

                    if (resultado.esCorrecto) {

                        let data = resultado.dato;

                        $('#IdCategoria').val(data.idCategoria);
                        $('#Nombre').val(data.nombre);
                        $('#Descripcion').val(data.descripcion);

                        $('#modalEditarCategoria').modal('show');
                    }

                }

            );

        }

    };

    $(document).ready(() => Categoria.init());

})();