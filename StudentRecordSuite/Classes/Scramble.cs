// Version history:
//   1.0     First working release
//   1.0.1   Added debug mode, and the functions must now be initialized before use.
//   1.1     Fixed possible security leak where if a repeating message such as "ffffffffff" is encoded,
//           a repeating message like "%syqqqqqqq" is also possible. However, despite that repeating letters
//           is now solved, the effectivity depends on password strength. For example, if the password used is
//           very short (e.g. 4 characters), then encoding "fffffffffffffff" might result in "r7wW9rW9rW9rW9r"
//           so repeating is still present on groups of characters.
//   1.2     Fixed possible security leak where if a message is decoded with a very similar password
//           from the original, then the message is partially readable.
//   1.3     Now able to detect if the used password is wrong.
//   1.4     Now able to detect if the data was altered before decryption (tampered). This routine
//           is also triggered if the password is wrong.
//   1.5     Changed API a bit for password entry--is now not passed multiple times like before.
//   1.6     More secure encryption. Also, several wrong passwords are allowed before forcefully exiting.
//           This counter is set with EncoderSetExit()
//   2.0     After researching more about cryptography and encryption, I made efforts to improve security.
//           Now, the password is NOT used directly--instead, a 448-bit (7 bits * 64) encryption key
//           is derived from the original password and is used for encryption instead of the original password.
//           Because of this, 0-length passwords are NO LONGER ALLOWED even in debug mode (this is a technical
//           limitation and not just my whim). At least 1 character now required. This also means that
//           the problem in version 1.1 is still unsolved, but due to the very long password, the repetition
//           will only occur every 64 characters, which is very unlikely especially when the original
//           message is not repetitive.
//   2.0.1   Ported to C# for StudentRecordSuite by Kyle Alexander Buan
//
//   "Scramble" algorithm by Kyle Alexander Buan (tar.shoduze@gmail.com)
//   Latest version released on January 14, 2015

using System;
using System.Windows.Forms;

namespace StudentRecordSuite
{
    static class Scramble
    {
        static bool IsDebug;
        static bool IsInitiated;
        static string P;
        static bool HasPWError;
        static bool HasCSError;
        static string ExtError;
        static bool Ex;
        static int RemainError;
        static string PreviousKey;
        static Random r;
        
        static int DecRes;

        public static int CheckDecRes()
        {
            return DecRes;
        }

        public static void EncoderSetExit(bool E, int C)
        {
            Ex = E;
            RemainError = C - 1;
        }

        private static int Random()
        {
            return 96 * r.Next();
        }

        private static string Strengthen(string P)
        {
            int I, J, L;
            L = P.Length;

            // Convert Password to ASCII
            char[] OldPArray = new char[P.Length];
            for (I = 0; I < L; I++)
            {
                OldPArray[I] = (char)(P[I] - 32);
            }

            // Derive NewPArray from OldPArray
            char[] NewPArray = new char[65];
            // Get new key
            for (I = 0; I < 50000; I++)
            {
                r = new System.Random(OldPArray[I % L]);
                for (J = 0; J < 64; J++)
                    NewPArray[J] = (char)((NewPArray[J] + Random()) % 950;
            }

            // Normalize data
            for (I = 0; I < 65; I++)
                NewPArray[I] = (char)(NewPArray[I]+32);

            // Convert data to string and add checksum
            string T = "";
            for (I = 0; I < 65; I++)
                T += NewPArray[I];

            if (IsDebug)
                MessageBox.Show(PreviousKey + "\n" + T, "Generated key");

            PreviousKey = T;
            return T;
        }

        public static void InitializeEncoder(string Pass, bool D)
        {
            if (Pass.Length < 1)
            {
                MessageBox.Show("Password too short!", "Encrypt init error");
                return;
            }

            IsDebug = D;
            P = Strengthen(Pass);
            ExtError = "";
            HasPWError = false;
            HasCSError = false;
            IsInitiated = true;
        }

        public static void UnloadEncoder()
        {
            P = "";
            IsInitiated = false;
        }

        public static void SetError(string E)
        {
            ExtError = "\n" + E;
        }

        public static string Encode(string S)
        {
            if (!IsInitiated)
            {
                MessageBox.Show("Encoder not yet initiated", "Encoder error");
                return "";
            }

            int I, J, K;

            if (S.Length == 0)
            {
                return "";
            }

            // convert String to ASCII while inverting it
            char[] SArray = new char[S.Length];
            string Original;
            Original = S;
            S = " " + S;
            K = S.Length;
            for (I = 0; I < S.Length; I++)
            {
                SArray[I] = (char)(S[K] - 32);
                K--;
            }

            // calculate checksum
            int Checksum = 0;
            for (I = 0; I < S.Length; I++)
                Checksum += SArray[I];
            Checksum = (Checksum % 95) + 32;

            // convert key to ascii
            char[] PArray = new char[P.Length];
            for (I = 0; I < P.Length; I++)
                PArray[I] = (char)(P[I] - 32);

            // encode data
            for (K = 0; K <= PArray[P.Length - 1]; K++)
                for (I = 0; I < S.Length; I += PArray[1] % 3 + 3)
                    for (J = 0; J < P.Length; J++)
                        SArray[I+]
        }
    }
}

/*
    
    ' Encode Data
    For K = 0 To PArray(Len(P))
        For I = 1 To Len(S) Step((PArray(2) Mod 3) + 3)
            For J = 1 To Len(P)
                SArray(I + J - 1) = (SArray(I + J - 1) + PArray(J)) Mod 95
            Next J
        Next I
    Next K
    
    ' Normalize Data
    For I = 1 To Len(S)
        SArray(I) = SArray(I) + 32
    Next I
    
    ' Convert Data to String and add checksum
    Dim T As String
    For I = 1 To Len(S)
        T = T + Chr$(SArray(I))
    Next I
    T = Chr$(Checksum) + T
    
    ' Debug
    If IsDebug Then
        If(Len(Original)) <> (Len(T) - 2) Then MsgBox "Length has changed!", vbOKOnly, "Encoder debug"
    End If


    Encode = T

End Function

Public Function Decode(ByVal S As String) As String
    If Not IsInitiated Then
        MsgBox "Encoder not yet initiated.", vbOKOnly, "Encoder error"
        End
    End If

    Dim I, J, K As Integer

    If Len(S) = 0 Then
        Decode = ""
        Exit Function
    End If
    
    ' Convert String to ASCII
    Dim SArray(1000) As Integer
    For I = 1 To Len(S)
        SArray(I) = Asc(Mid$(S, I, 1)) - 32
    Next I
    
    
    
    ' Convert key to ASCII
    Dim PArray(100) As Integer
    For I = 1 To Len(P)
        PArray(I) = Asc(Mid$(P, I, 1)) - 32
    Next I
    
    ' Decode Data
    For K = 0 To PArray(Len(P))
        For I = 2 To Len(S) Step((PArray(2) Mod 3) + 3)
            For J = 1 To Len(P)
                If(SArray(I + J - 1) - PArray(J)) < 0 Then SArray(I + J - 1) = SArray(I + J - 1) + 95
                SArray(I + J - 1) = (SArray(I + J - 1) - PArray(J))
            Next J
        Next I
    Next K
    
    ' Calculate checksum
    Dim Checksum As Integer
    Checksum = 0
    For I = 2 To Len(S)
        Checksum = Checksum + SArray(I)
    Next I
    Checksum = (Checksum Mod 95) + 32
    
    ' Normalize Data
    For I = 1 To Len(S)
        SArray(I) = SArray(I) + 32
    Next I
    
    ' Convert Data to String while inverting it
    Dim T As String
    For I = 2 To Len(S) - 1
        T = Chr$(SArray(I)) + T
    Next I

    DecRes = 0
    If IsDebug Then
        If Len(S) <> (Len(T) + 2) Then MsgBox "Length has changed from " + Str$(Len(S)) + " to " + Str$(Len(T) + 2), vbOKOnly, "Encoder debug"
        If SArray(Len(S)) <> 32 Then MsgBox "Wrong password detected " + Str$(SArray(Len(S))), vbOKOnly, "Encoder debug"
        If SArray(1) <> Checksum Then MsgBox "Wrong checksum detected! Data was most probably altered, or you used a wrong password. (expected " + Str$(Checksum) + " but got " + Str$(SArray(1)), vbOKOnly, "Encoder debug"
    Else
        If SArray(Len(S)) <> 32 Then
            DecRes = -1
            MsgBox "Wrong password detected." + Chr(10) + "This means that the password used to create the data files is not the same as the password you are using now." + Chr(10) + "This may be a simple human mistake but may also mean that someone may have edited the data files without permission." + ExtError, vbOKOnly, "Decoder error"
            If Ex Then
                If RemainError = 0 Then
                    End
                Else
                    RemainError = RemainError - 1
                End If
            End If
        ElseIf SArray(1) <> Checksum Then
            DecRes = -1
            MsgBox "Wrong checksum detected." + Chr(10) + "This means that the data files were edited in a text editor (such as Notepad) before they were accessed now." + Chr(10) + "This may indicate that someone edited the data files without permission," + Chr(10) + "or maybe the password used was just wrong." + ExtError, vbOKOnly, "Decoder error"
            If Ex Then
                If RemainError = 0 Then
                    End
                Else
                    RemainError = RemainError - 1
                End If
            End If
        End If
    End If


    Decode = T
End Function


    }
} */