<p># Furion Game Framework (based on Entita)</p>
<p>請另外下載 Entitas 共用之<br />https://github.com/sschmid/Entitas-CSharp<br />版本為3.6.1</p>
<ul>
<li>
<h2>Bootstrapper</h2>
<br />請務必在所有場景之中放置一個擁有Bootstrapper的Game Object</li>
<li>
<h2>Entity</h2>
<br />一樣"東西", 作用是讓Component依附上它!</li>
<li>
<h2>Component</h2>
<br />遊戲資料的載體 沒有邏輯在內 可以分拆得十分仔細<br />所有Component定義放於 /Components/Components.cs 中<br />
<h3>Furion Defined:</h3>
<ul>
<li>Scene Config<br />
<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">儲存現時場景的 Scene Type, 在 Bootstrapper 去定義現時的Scene Type。</blockquote>
</li>
<li>Listener Component<br />
<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">用於接收自訂事件，必須實作 IHandle&lt;T&gt; 的 Callback</blockquote>
</li>
<li>View</li>
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
<li>Scene Management System<br>
  主要的場景管理系統，能夠監察 Scene Config 的變化載入不同的子 System，並且會載入對應的 Unity Scene<br>至於 Scene Type 及 Subsystem 的對應定義在 /Components/SceneConfig.cs之中</li>
</ul>
</li>
<li>
<h2>Entity Behaviour</h2>
<br /> 用於一早已放置在Unity Scene的物件作初始化用途</li>
</ul>
<p><br /> <br /> Scene Management System<br /> - 根據 SceneConfig 中的 SceneType會載入不同的Subsystem<br /> <br />Component- 主要Component, 遊戲資料的載體 沒有邏輯在內 可以分拆得十分仔細</p>
<p>Scene Config<br /> - 儲存現時場景的 SceneType</p>
<p>Listener Component<br /> - 亦是一種Component, 用於接收對應事件再進行下一步的動作</p>
<p>Entity Behaviour<br /> - 用於一早已放置在Unity Scene的物件作初始化用途</p>
<p>View</p>
