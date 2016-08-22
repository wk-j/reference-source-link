## Reference Source Link

How to create link that match code in http://referencesource.microsoft.com.

## Signature

We need two signature to create URL.

- Assembly name (`mscorlib`)
- Symbol ID (`M:System.Int32.TryParse(System.String,System.Int32@)`)

## Symbol ID prefix

- M: = Method
- E: = Event
- T: = Type
- P: = Property
- F: = Field

## How to create URL

1. Encode symbol ID with following hash function.

    ```csharp
    public static string GetMD5Hash(string input, int digits) {
    	using (var md5 = MD5.Create()) {
    		var bytes = Encoding.UTF8.GetBytes(input);
    		var hashBytes = md5.ComputeHash(bytes);
    		return ByteArrayToHexString(hashBytes, digits);
    	}
    }

    public static string ByteArrayToHexString(byte[] bytes, int digits = 0) {
    	if (digits == 0) {
    		digits = bytes.Length * 2;
    	}
    	char[] c = new char[digits];
    	byte b;
    	for (int i = 0; i < digits / 2; i++) {
    		b = ((byte)(bytes[i] >> 4));
    		c[i * 2] = (char)(b > 9 ? b + 87 : b + 0x30);
    		b = ((byte)(bytes[i] & 0xF));
    		c[i * 2 + 1] = (char)(b > 9 ? b + 87 : b + 0x30);
    	}
    	return new string(c);
    }
    ```
2. Create URL from assembly name and hash value.

    ```csharp
    var hash = GetMD5Hash("M:System.Int32.TryParse(System.String,System.Int32@)", 16);
	var assemblyName = "mscorlib";
	var baseUrl = "http://referencesource.microsoft.com";
	var url = baseUrl + "/" + assemblyName + "/a.html#" + hash;
    ```

3. Try in browser.

    - http://referencesource.microsoft.com/mscorlib/a.html#325507e509229dbc

## Resources

- https://github.com/SLaks/Ref12
- https://github.com/KirillOsenkov/SourceBrowser