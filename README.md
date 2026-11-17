## Como funciona el programa
1. El programa crea una conexión con new SqliteConnection("Data Source=productos.db"), que indica el archivo de base de datos a usar. Al ejecutar connection.Open() se abre la conexión y, si el archivo no existe, SQLite lo crea. Desde ese momento, los comandos se ejecutan sobre esa base de datos.
2. Se crea la tabla productos con un SqliteCommand (CreateCommand()). El SQL se asigna en CommandText y se ejecuta con ExecuteNonQuery(). La tabla tiene cuatro columnas: id (entero que se genera automáticamente), nombre, precio y stock.
3. Se eliminan los registros anteriores con DELETE FROM productos, para que el programa no duplique datos cada vez que se ejecuta.
4. Se insertan tres registros recorriendo el arreglo productos con un foreach. Cada inserción usa un SqliteCommand con parámetros ($nombre, $precio, $stock), ademas el programa muestra en consola cada inserción y el total de registros antes y después.
5. Se consultan los registros con SELECT y ExecuteReader(). El SqliteDataReader se recorre con while (reader.Read()), y cada fila se muestra en consola.
6. Todos los objetos (conexión, comandos y reader) se declaran con using, para que sus recursos se liberen automáticamente al terminar.

## Instrucciones para ejecutar

1. Instala el SDK de .NET 8: https://dotnet.microsoft.com/download
2. Abre una terminal y entra a la carpeta del proyecto:
   ```
   cd "ruta\de\la\carpeta\programa-ado"
   ```
3. Ejecuta:
   ```
   dotnet run
   ```
