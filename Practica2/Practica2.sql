
Create database practica2;

Use practica2;


CREATE TABLE categorias (
    id_categoria INT PRIMARY KEY Identity,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(255)
);


CREATE TABLE productos (
    id_producto INT PRIMARY KEY Identity,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL,
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria)
);
INSERT INTO categorias (nombre, descripcion) VALUES
('Bebidas', 'Productos líquidos para consumo'),
('Snacks', 'Aperitivos y bocadillos'),
('Lácteos', 'Productos derivados de la leche');

-- Bebidas
INSERT INTO productos (nombre, precio, stock, id_categoria) VALUES
('Agua Mineral', 800, 50, 1),
('Jugo de Naranja', 1200, 30, 1);

-- Snacks
INSERT INTO productos (nombre, precio, stock, id_categoria) VALUES
('Papas Fritas', 1500, 40, 2),
('Galletas', 2000, 35, 2);

-- Lácteos
INSERT INTO productos (nombre, precio, stock, id_categoria) VALUES
('Leche Entera', 2500, 25, 3),
('Queso Mozzarella', 5000, 15, 3);