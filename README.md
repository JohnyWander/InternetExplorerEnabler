# IExplorerEnabler
Do you use some web apps/programs that work only in Internet Explorer?
You can't do it because microsoft decided that opening IE should start Edge? 

Here's simple fix that stops this from happening by revoking "Run" permissions(All users) from Edge files
responsible for this behaviour. - <br>
ie_to_edge_bho.dll<br>
ie_to_edge_bho_64.dll<br>
ie_to_edge_stub.exe<br>

You must run it as Administrator

Releases contains version for .NET framework 6.0 (small .exe)
And Self-Contained one (big .exe)

Antivirus software may detect this program as a threat as it is bulk changing file permissions.
(Especially when you have many Edge versions)
