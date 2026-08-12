1. Name 
    - Secure File Vault System

        + The Secure File Vault System is a console-based security application designed to protect sensitive files through encryption and controlled access.

        + The system allows users to securely upload, store, view, and download files. All uploaded files are automatically encrypted before storage. Access to files is restricted based on user roles and permissions managed by the system administrator (**ONLY HAVE ONE**).

        + The system also logs all actions and detects suspicious activities such as repeated unauthorized access attempts.

        + This project demonstrates how core cybersecurity principles can be implemented using object-oriented programming.


2. System Overview
    - The Secure File Vault System simulates a personal secure storage environment.

    - There are two types of users:
        + Administrator (**just have one**)
            * Full system access
            * Can upload and delete files
            * Can create viewer accounts
            * Can assign file-level permissions
            * Can view system logs

        + Viewer
            * Can only view and download files assigned to them
            * Cannot upload or delete files

3. File Security Mechanism
    - When a file is uploaded:
        * The system encrypts the file automatically.
        * The encrypted version is stored in the vault.
        * The administrator may optionally delete the original file.

    - When a file is viewed:
        * The system temporarily decrypts the file.
        * The file is opened using the operating system’s default application.
        * Temporary decrypted files are deleted when the program exits.

    - When a file is downloaded:
        * The file is decrypted and saved to a user-selected location.
    
    - **All actions are logged, and repeated unauthorized access attempts may result in account suspension.**

4. OOP objective
    - This project is specifically designed to demonstrate strong object-oriented programming principles.

    - Abstraction
        - Core concepts such as User, FileMetadata, EncryptionStrategy, and AccessControl are modeled as abstract entities to represent real-world security components.

    - Encapsulation
        - Sensitive operations such as encryption, file handling, and permission checking are encapsulated within dedicated service classes.

    - Inheritance
        - Different user types (Admin and Viewer) inherit from a common abstract User class.

    - Polymorphism
        - Interfaces such as IEncryptionStrategy and ILogger allow interchangeable implementations without modifying existing system logic.

    - Separation of Concerns
        - Each service is responsible for a single task:
            - AuthenticationService handles login validation
            - EncryptionService handles encryption/decryption
            - StorageService manages file storage
            - PermissionService manages file-level permissions
            - AccessControlService validates user access
            - IncidentDetector monitors suspicious behavior

5. Core system workflow
    1. Application Startup
        - Start Program
        - ↓
        - Initialize Services
        - ↓
        - Display Main Menu

    2. Authentication Phase
        - User selects Login
        - ↓
        - AuthenticationService validates credentials
        - ↓
        - If login fails multiple times → account locked
        - ↓
        - Successful login creates active session

    3. Upload File (Admin Only)
        - Admin selects Upload
        - ↓
        - AccessControlService verifies permission
        - ↓
        - File is read
        - ↓
        - EncryptionService encrypts file
        - ↓
        - StorageService saves encrypted file
        - ↓
        - Admin optionally deletes original file
        - ↓
        - Log event

    4. View File
        - User selects file
        - ↓
        - AccessControlService verifies permission
        - ↓
        - Encrypted file loaded
        - ↓
        - EncryptionService decrypts file to temporary folder
        - ↓
        - File opened using OS default application
        - ↓
        - Log event

    5. Download File
        - User selects file
        - ↓
        - AccessControlService verifies permission
        - ↓
        - File decrypted
        - ↓
        - File saved to chosen location
        - ↓
        - Log event

    6. Application Exit
        - User exits program
        - ↓
        - TemporaryFileManager deletes all decrypted temporary files
        - ↓
        - Session ends

6. Real-World Relevance
    - This system simulates the core principles behind secure personal file storage systems.

    - It demonstrates:
        - Encryption before storage

        - Role-based access control

        - File-level permission management

        - Secure temporary file handling

        - Logging and incident monitoring

    - ***While it is not intended to defend against advanced system-level attacks, it provides effective personal-level protection for sensitive files in everyday environments.***
7. Entities
    - Layers:
        - Domain layer: Represents the core concepts of the system
            - It defines: 
                - Who exist in the system
                - What entities are involved
                - How they relate to each other
                - => It does not handle technical details like file writing or encryption algorthms

        - Service layer: (is anything work for domain) contains the business logic of the system
            - It defines:
                - How users authenticate
                - How permissions are checked
                - How files are processed
                - => It coordinates operations between domain objects

        - Infrastructure layer: handles technical details and external systems
            - It deals with: 
                - File system access
                - Encryption libraries
                - Logging to disk
                - Operating system interaction
                - => It is the concrete implementation of interfaces defined in the service layer
        - Dễ hiểu : Domain (thực đơn), Service (đầu bếp), infrastructure (bếp ga, nồi, điện)
    
    - Entities:
        - Domain layer:
            - user (abstract)
                - Id (string)
                - Username (string)
                - PasswordHash (string)
                - Salt (byte[])
                - AccountState (AccountState enum)
            - AdminUser
            - ViewerUser
            -  FileMetadata
                - File_id (string)
                - OriginalFileName (string)
                - Owner_id (string) -> Admin upload
                - CreatedAt (DateTime)
            - FilePermission
                - UserId (string)
                - File_Id (string)
            - AccountState (enum)
                - Active or Locked
           
        - Service layer:
            - AuthenticationService
                - What will do
                    - Register admin (1 admin only)
                    - Register viewer (by admin)
                    - Login
                    - Hash password
                    - lock account

                - Method signature:
                    - _users (list)
                    - AdminExists: bool
                    - RegisterAdmin: User (username(string), password(string))
                    - RegisterViewer: User (username(string), password(string))
                    - Login: User(username(string), password(string))
                    - LockAccount: void (User user)

                    - _GenerateSalt: byte[]
                    - _HashPassword: byte[] (password(string), salt(byte[]))
                    - _VerifyPassword: bool (inputPassword(string), storeHash(string), storeSalt(byte[]))

            - PermissionService
                - What will do
                    - GrantPermission (user_id, file_id)
                    - RevokePermission (user_id, file_id)
                    - CheckPermission (user_id, file_id)
                
                - Method signature:
                    - _permissions : (list)
                    - GrantPermission: void (user_id(string), File_id(string))
                    - RevokePermissions: void(string user_id, string file_id)
                    - HasPermissions: bool(string user_id, string file_id)
                    - GetUserFileIds: List(string) (string user_id)
                    - RemovePermissionsByFile: void (string file_id)

            - AccessControlService
                - What will do
                    - Check permission before acting
                    - if admin -> true, if viewer -> call PermissionService
                
                - Method signature: 
                    - _permission_service: PermissionService
                    - AccessControlService : (PermissionService permissionService)
                    - CanAccess: bool (User user, string file_id)

            

            - IncidentDetector
                - What will do
                    - Purpose : observe incident
                    - Count failed login
                    - Count unauthorized access
                
                - Method signature:
                    - _violations : Dictionary<string, int>
                    - _maxAttempts : int
                    - void RecordViolation (string userId)
                    - bool ShouldLockAccount(string userId)
                    - void Reset(string userId)

        - Infrastructure Serivce
            - MasterKeyManager:
                - _keyFilePath: string
                - KeyExists(): bool
                - GenerateAndSaveKey(): byte[]
                - LoadKey(): byte[]
            - UserRepository
                - LoadUser()
                - SaveUser()
            - TempFileManager
                - Purpose : manage file temporarily when read file
                - CreatTempFile (data)
                - Cleanup()

            - FileStorageService
                - What will do: 
                    - Purpose : Encrypt, decrypt, Save and Read file encrypted from VaultStorage
                    - SaveEncrypted (file_id, data)
                    - LoadEncrypted (file_id)
                    - Delete (file_id)
                    - Exists (file_id)
                
                - Method signature:
                    - _storagePath: string
                    - _encryptionKey: byte[]
                    - FileStorageService(storagePath : string, encryptionKey : byte[])
                    - Save: void (string fileId, byte[] data)
                    - Load: byte[] (string fileId)
                    - Delete: void (string fileId)
                    - Exists: bool (string fileId)

                    - _Encrypt(data : byte[]) : byte[]
                    - _Decrypt(encryptedData : byte[]) : byte[]
                        - => use System.Security.Cryptography.Aes

        - Applicarion Layer:
            - VaultController (Application layer control)
                - What will do:
                    - Control whole system
                    - take input from user
                    - Call respective service
                    - generate GUID
                
                - Method signature
                    - void UploadFile(User user, string filePath)
                    - void ViewFile(User user, string fileId)
                    - void DownloadFile(User user, string fileId, string savePath)
                    - void DeleteFile(User user, string fileId)
                    - void GrantFileAccess(string viewerId, string fileId)
                    - List<FileMetadata> ListFiles(User user)

        - ***Flow Upload***
            - VaultController
            - -> AccessControlService
            - -> FileStorageService
            - -> PermissionSerive (if needful)
            - -> Logger

        - ***Flow Login***
            - VaultController
            - -> AuthenticationService
            - -> IncidentDetector

8. Dependency Map
    - Domain
        - -> Do not depend on anything
    - Services Dependency Map
        - AuthenticationService
            - -> user
            - -> adminUser
            - -> ViewerUser
            - -> Role
            - -> AccountState
        - PermissionService
            - -> FilePermission
        - AccessControlService
            - -> PermissionService
            - -> User
            - -> Role
        - EncryptionService
            - IEncryptionStrategy
        - StorageService
            - -> System.IO
        - IncidentDetector
            - -> User
    - Infrastructure
        - UserRepository
        - AESEncryptionStrategy
            - -> IEncryptionStrategy
            - -> System.Security.Cryptography
