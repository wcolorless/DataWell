# DataWell (alpha 0.0.1)
A cache for storing data in RAM on the server. Saves data in collections for further processing on the client side.

The client creates the entity of the stored data. Uses this entity to create a collection. A collection can store entity type data. It then generates and stores data in the Data Well. The client can work with data.
Messaging takes place using the selected protocol (WebSocket).

The client may:
- Create and delete collections.
- Save data (single item or batch).
- Reading data by Id record or the entire collection.
- Data search by field values (Equal, Not Equal, Greater, Less, etc.)
- Delete records.

Applications:
- IoT data storage.
- Data storage for applications running in the container.
- Log storage.

Plans:
- Add Http Data Transport.
- Data recovery after failures.
- Data Conservation (Cold Storage).
- Build a Docker image (for a quick start)


