<h1>Furion Game Framework</h1>
<p>這是Furion基於Entita之上的Unity遊戲製作框架，將所有Code放進Unity的Asset資料夾就可以使用。</p>
<ul>
<li>
<h2>Bootstrapper</h2>
<br />請務必在所有場景之中放置一個擁有Bootstrapper的Game Object</li>
<li>
<h2>Entity</h2>
<br />一樣"東西", 作用是讓Component依附上它!</li>
<li>
<h2>Component</h2>
<br />遊戲資料的載體 沒有邏輯在內 可以分拆得十分仔細<br />所有Component定義放於 /Components 中<br />
<h3>Furion Defined:</h3>
<ul>
<li>Scene Config<br />
<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">儲存現時場景的 Scene Type, 在 Bootstrapper 去定義現時的Scene Type。</blockquote>
</li>
<li>Listener Component<br />
<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">用於接收自訂事件，必須實作 IHandle&lt;T&gt; 的 Callback</blockquote>
</li>
<li>View
  <blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">用於讓System直接操作Game Object的連繫</blockquote>
  </li>
 
</ul>
</li>
<li>
<h2>Context</h2>
<br />用於創造及刪除Entity, 亦是一個Pool，減少取用新Entity時的資源耗用</li>
<li>
<h2>System</h2>
<br />能夠監察Component變化, 並可以得知有關Entity是誰，遊戲的主要邏輯亦在此進行。<br />所有System定義於 /Systems 之內<br />
<h3>Furion Defined:</h3>
<ul>
<li>Scene Management System<br />
<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">主要的場景管理系統，能夠監察 Scene Config 的變化載入不同的子 System，並且會載入對應的 Unity Scene<br />至於 Scene Type 及 Subsystem 的對應定義在 /Components/SceneConfig.cs之中</blockquote>
</li>
</ul>
</li>
<li>
<h2>Entity Behaviour</h2>
<br /> 用於一早已放置在Unity Scene的物件作初始化用途</li>
</ul>
<p>&nbsp;</p>
