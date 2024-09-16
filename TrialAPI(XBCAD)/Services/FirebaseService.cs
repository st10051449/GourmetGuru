namespace TrialAPI_XBCAD_.Services
{
    using FirebaseAdmin;
    using Firebase.Database;
    using Firebase.Database.Query;
    using Google.Apis.Auth.OAuth2;

    public class FirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            // Initialize Firebase App
            var app = FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(@"C:\Users\lab_services_student\Desktop\Firebase\gourmetguru-23c0a-firebase-adminsdk-dw05q-ff1f389dae.json")
            });

            // Firebase Realtime Database URL
            _firebaseClient = new FirebaseClient("https://console.firebase.google.com/project/gourmetguru-23c0a/database/gourmetguru-23c0a-default-rtdb/data/~2F");
        }

        // Method to retrieve Firebase Client
        public FirebaseClient GetFirebaseClient()
        {
            return _firebaseClient;
        }
    }
}