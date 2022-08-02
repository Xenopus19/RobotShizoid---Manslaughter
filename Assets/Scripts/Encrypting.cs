using UnityEngine;

public class Encrypting : MonoBehaviour
{
    private static int EncryptValue = 1;

    void Awake() =>
        GenerateValue();

    private void GenerateValue() =>
        EncryptValue = Random.Range(4, 100);

    public static int Encrypt(int inComing) =>
        inComing * EncryptValue;

    public static int Decipher(int inComing) =>
        inComing / EncryptValue;
}
