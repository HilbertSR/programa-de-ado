using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection("Data Source=productos.db");
connection.Open();
Console.WriteLine("Conexión establecida con productos.db");

using (var crearTabla = connection.CreateCommand())
{
    crearTabla.CommandText = """
    CREATE TABLE IF NOT EXISTS productos (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nombre TEXT NOT NULL,
        precio REAL NOT NULL,
        stock INTEGER NOT NULL
    )
    """;
    crearTabla.ExecuteNonQuery();
}

using (var limpiar = connection.CreateCommand())
{
    limpiar.CommandText = "DELETE FROM productos";
    limpiar.ExecuteNonQuery();
}

var productos = new (string Nombre, double Precio, int Stock)[]
{
    ("Teclado", 350.00, 20),
    ("Mouse", 150.50, 50),
    ("Monitor", 1200.00, 10)
};

using (var contar = connection.CreateCommand())
{
    contar.CommandText = "SELECT COUNT(*) FROM productos";
    var total = Convert.ToInt64(contar.ExecuteScalar());
    Console.WriteLine($"Registros en la tabla: {total}");
}

foreach (var p in productos)
{
    using var insertar = connection.CreateCommand();
    insertar.CommandText = "INSERT INTO productos (nombre, precio, stock) VALUES ($nombre, $precio, $stock)";
    insertar.Parameters.AddWithValue("$nombre", p.Nombre);
    insertar.Parameters.AddWithValue("$precio", p.Precio);
    insertar.Parameters.AddWithValue("$stock", p.Stock);
    
    int filas = insertar.ExecuteNonQuery();
    Console.WriteLine($"Insertado: {p.Nombre} - {p.Precio} - {p.Stock} (filas afectadas: {filas})");
}

// 5. Consultar y mostrar con SqliteDataReader
using var consultar = connection.CreateCommand();
consultar.CommandText = "SELECT id, nombre, precio, stock FROM productos";

using var reader = consultar.ExecuteReader();

Console.WriteLine("\nProductos almacenados:");
while (reader.Read())
{
    Console.WriteLine($"{reader.GetInt64(0)} - {reader.GetString(1)} - {reader.GetDouble(2)} - {reader.GetInt64(3)}");
}