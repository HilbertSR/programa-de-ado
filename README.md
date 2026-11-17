## Como funciona el programa
1. El programa crea la base de datos usando "using var connection = new SqliteConnection("Data Source=productos.db");" y luego se abre con "connection.Open();" de esa manera lo que se ejecute despues sera en la base de datos.
2. Luego se crea la tabla con createCommand y se crean también las filas de la tabla que serian el ID que es generado automaticamente, el nombre, el precio y el stock.
3. Se insertan los datos que están en productos con parametros
4. Por ultimo se consulta la informacion y se lee

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
