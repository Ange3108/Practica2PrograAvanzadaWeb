(() => {

    const Producto = {

        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();
        },

        inicializarTabla() {

            this.tabla = $('#tblProducto').DataTable({

                ajax: {
                    url: '/Producto/GetProductos',
                    type: 'GET',
                    dataSrc: 'dato'
                },

                columns: [

                    { data: 'idProducto' },

                    { data: 'nombre' },

                    { data: 'precio' },

                    { data: 'stock' },

                    { data: 'idCategoria' },

                    {
                        data: null,
                        title: 'Acciones',
                        orderable: false,
                        render: (data, type, row) => {

                            return `
                                <button class="btn btn-sm btn-primary btn-editar"
                                        data-id="${row.idProducto}">
                                    Editar
                                </button>

                                <button class="btn btn-sm btn-danger btn-eliminar"
                                        data-id="${row.idProducto}">
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

            $('#tblProducto').on('click', '.btn-editar', function () {

                const id = $(this).data('id');

                Producto.cargarProducto(id);

            });

            $('#tblProducto').on('click', '.btn-eliminar', function () {

                const id = $(this).data('id');

                Producto.eliminarProducto(id);

            });

            $('#btnGuardarProducto').on('click', function () {

                Producto.guardarProducto();

            });

            $('#btnEditarProducto').on('click', function () {

                Producto.editarProducto();

            });

        },

        guardarProducto() {

            let form = $('#formCrearProducto');

            if (!form.valid()) {
                return;
            }

            $.ajax({

                url: '/Producto/CreateProducto',
                type: 'POST',
                data: form.serialize(),

                success: function (respuesta) {

                    if (respuesta.esCorrecto) {

                        $('#modalCrearProducto').modal('hide');

                        form[0].reset();

                        Producto.tabla.ajax.reload();

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

        editarProducto() {

            let form = $('#formEditarProducto');

            if (!form.valid()) {
                return;
            }

            $.ajax({

                url: '/Producto/UpdateProducto',
                type: 'POST',
                data: form.serialize(),

                success: function (respuesta) {

                    if (respuesta.esCorrecto) {

                        $('#modalEditarProducto').modal('hide');

                        form[0].reset();

                        Producto.tabla.ajax.reload();

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

        eliminarProducto(id) {

            Swal.fire({

                title: '¿Está seguro?',
                text: 'No podrá revertir esta operación',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí, eliminar'

            }).then((result) => {

                if (result.isConfirmed) {

                    $.ajax({

                        url: `/Producto/DeleteProducto?id=${id}`,
                        type: 'DELETE',

                        success: function (respuesta) {

                            if (respuesta.esCorrecto) {

                                Producto.tabla.ajax.reload();

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
                                text: 'Ocurrió un error al eliminar el producto',
                                icon: 'error'
                            });

                        }

                    });

                }

            });

        },

        cargarProducto(id) {

            $.get(

                `/Producto/GetProductoById?id=${id}`,

                function (resultado) {

                    if (resultado.esCorrecto) {

                        let data = resultado.dato;

                        $('#IdProducto').val(data.idProducto);
                        $('#Nombre').val(data.nombre);
                        $('#Precio').val(data.precio);
                        $('#Stock').val(data.stock);
                        $('#IdCategoria').val(data.idCategoria);

                        $('#modalEditarProducto').modal('show');
                    }

                }

            );

        }

    };

    $(document).ready(() => Producto.init());

})();