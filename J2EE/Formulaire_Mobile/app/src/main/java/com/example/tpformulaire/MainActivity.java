package com.example.tpformulaire;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "MainActivity";

    private EditText editTextFirstName, editTextLastName, editTextEmail, editTextDateOfBirth, editTextDescription, editTextComment;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Initialisation des vues
        editTextFirstName = findViewById(R.id.editTextFirstName);
        editTextLastName = findViewById(R.id.editTextLastName);
        editTextEmail = findViewById(R.id.editTextEmail);
        editTextDateOfBirth = findViewById(R.id.editTextDateOfBirth);
        editTextDescription = findViewById(R.id.editTextDescription);
        editTextComment = findViewById(R.id.editTextComment);

        // Récupération du bouton "Ok"
        Button buttonOk = findViewById(R.id.buttonOk);
        buttonOk.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Récupération des données saisies
                String firstName = editTextFirstName.getText().toString();
                String lastName = editTextLastName.getText().toString();
                String email = editTextEmail.getText().toString();
                String dateOfBirth = editTextDateOfBirth.getText().toString();
                String description = editTextDescription.getText().toString();
                String comment = editTextComment.getText().toString();

                // Affichage des données saisies dans le Logcat
                Log.i(TAG, "Prénom: " + firstName);
                Log.i(TAG, "Nom: " + lastName);
                Log.i(TAG, "Email: " + email);
                Log.i(TAG, "Date de naissance: " + dateOfBirth);
                Log.i(TAG, "Description: " + description);
                Log.i(TAG, "Commentaire: " + comment);
            }
        });
        // Récupération du bouton "Annuler"
        Button buttonCancel = findViewById(R.id.buttonCancel);
        buttonCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Effacer les champs du formulaire
                editTextFirstName.setText("");
                editTextLastName.setText("");
                editTextEmail.setText("");
                editTextDateOfBirth.setText("");
                editTextDescription.setText("");
                editTextComment.setText("");

                // Affichage d'un message de confirmation dans le Logcat
                Log.i(TAG, "Champs effacés");
            }
        });
    }
}