# PruebaTecnica
Prueba
En este repositorio encontrarán el servicio que se creo para la prueba técnica, para esta prueba se utilizó arquitectura hexagonal.

El proyecto cuenta con las siguientes capas:

1. Capa de datos: Desde esta capa realizamos el registro en base de datos de la información obtenida del servicio y realizamos la consulta de la información guardada como de los datos necesarios para el informe.
2. Capa de servicios: A través de esta capa nos conectamos al servicio para obtener la información.
3. Capa de negocio: Es el core de la aplicación es donde unimos todas las capas para realizarlo se crean interfaces que deben implementarse en las diferentes capas.
4. Capa de presentación: A través de esta capa estamos esponiendo un servicio desde donde podemos iniciar el consumo y que también se conecta con la aplicación de angular.
5. Capa de entidades: En esta capa tenemos todas las entidades que se utilizarán en la aplicación.

![image](https://user-images.githubusercontent.com/15669601/153697965-efe4b0b2-b76c-4cff-b483-a5b7b9a91c76.png)
