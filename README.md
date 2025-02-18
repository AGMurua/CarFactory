# API de Ventas de Autos

Esta API permite gestionar operaciones relacionadas con las ventas de autos, centros de distribución y precios de autos. A continuación, se detallan las funciones disponibles y cómo probarlas.

## Configuracion

Desde el appsettings.json puede modificarse tanto los precios de los vehiculos como su impuesto de quererse. Por defecto solo el tipo "SPORT" tiene un impuesto del 7%.
Tambien se puede modificar y agregar nuevos centros de distribucion y ventas. Por defecto solo hay cuatro.

---

### **Middleware para medir tiempos de ejecucion**
- **Descripción**: Se solicito imprimir todos los tiempos de ejecucion de los metodos.
- **Solucion**: Se creo un middleware que se ejecuta en cada llamada para imprimir en consola los tiempos de ejecucion. 
- **Ubicacion**: Se encuentra en CarFactory\Middleware

<p align="center">
  <img src="https://i.imgur.com/hMvHijh.png" alt="Descripción de la imagen" width="300"/>
</p>

---

## Endpoints

### 1. **Agregar una nueva venta**
- **Endpoint**: `POST /api/sales/add`
- **Descripción**: Agrega una nueva venta a la base de datos.
- **Parámetros**: 
  - `saleDto`: Un objeto JSON con los datos de la venta:
    ```json
    {
      "CarType": 1, <-- Valor numerico asignado (ver punto 7 para mas detalle)
      "CenterId": 1
    }
    ```
- **Respuestas esperadas**:
  - **201 Created**: Venta agregada correctamente.
  - **400 Bad Request**: Si hay algún error en los datos.
  - **500 Internal Server Error**: Si ocurre un error inesperado.

---

### 2. **Obtener volumen total de ventas**
- **Endpoint**: `GET /api/sales/total-sales-volume`
- **Descripción**: Devuelve el volumen total de ventas en la base de datos.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    {
      "totalVolume": 150000
    }
    ```

---

### 3. **Obtener ventas por centro de distribución**
- **Endpoint**: `GET /api/sales/sales-by-center`
- **Descripción**: Devuelve las ventas agrupadas por centro de distribución.
- **Parámetros**:
  - `centerName` (opcional): Nombre del centro para filtrar las ventas. Si no se asina nigun centerName, devuelve todos los centros.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    {
      "Centro1": 50000,
      "Centro2": 100000
    }
    ```

---

### 4. **Obtener porcentaje de ventas por modelo por centro**
- **Endpoint**: `GET /api/sales/sales-percentage`
- **Descripción**: Devuelve el porcentaje de ventas por modelo de autos en cada centro.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    {
      "Centro1": {
        "Sedan": 60,
        "SUV": 40
      },
      "Centro2": {
        "Sedan": 30,
        "SUV": 70
      }
    }
    ```

---

### 5. **Obtener todos los centros**
- **Endpoint**: `GET /api/center/get-all`
- **Descripción**: Devuelve todos los centros de distribución registrados.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    [
      { "id": 1, "name": "Centro1", "location": "Ubicacion 1" },
      { "id": 2, "name": "Centro2", "location": "Ubicacion 2" }
    ]
    ```

---

### 6. **Obtener un centro por su id**
- **Endpoint**: `GET /api/center/{id}`
- **Descripción**: Devuelve un centro específico por su `id`.
- **Parámetros**:
  - `id`: El id del centro que quieres obtener.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    { "id": 1, "name": "Centro1", "location": "Ubicacion 1"}
    ```
  - **404 Not Found**: Si el centro con ese `id` no existe.

---

### 7. **Obtener todos los precios de los autos**
- **Endpoint**: `GET /api/car/get-all`
- **Descripción**: Devuelve todos los precios de los autos disponibles.
- **Respuesta esperada**:
  - **200 OK**:
    ```json
    [
      {
        "carType": 4, <--- valor utilizado a modo de "ID"
        "basePrice": 12500,
        "taxPercentage": 0, <--- porcentaje de impuesto
        "priceWithTaxes": 12500,
        "carTypeName": "OffRoad"
      }
    ]
    ```

---

## Resumen de Respuestas

- **201 Created**: Creación exitosa.
- **200 OK**: Todo correcto, se devuelven los datos.
- **400 Bad Request**: Problema con los datos enviados.
- **404 Not Found**: No se encuentra el recurso.
- **500 Internal Server Error**: Error inesperado en el servidor.

---

## Recomendaciones para probar la API

- Puede ejecutarse mediante dotnet run utilizando y usando [http://localhost:5140/swagger](http://localhost:5140/swagger/index.html).
- Puede ejecutarse mediante Visual Studio, por defecto https.

---

## Test automaticos

- Dentro de la solucion se encuentra una capa de test automaticos los mismos se pueden ejecutar desde visual studio.

<p align="center">
  <img src="https://i.imgur.com/7oVzCtw.png" alt="Test automaticos" width="300"/>
</p>

---
Con esta guía podrás probar todas las funciones de la API de ventas de autos.
