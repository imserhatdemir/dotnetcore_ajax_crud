# dotnetcore_ajax_crud
 asp.net core ajax crud işlemleri
 
 <h2>LİSTELEME İŞLEMİ</h2>
 <p>Model classında tanımladığımız tablodaki statik olarak girdiğimiz verileri aşağıdaki ajax komutuyla console ve arayüzde listeleme işlemi yapıyoruz</p>
   $("#btngetlist").click(function () {
        $.ajax({
            contentType: "application/json",
            dataType: "json",
            type: "GET",
            url: "/Admin/Writer/WriterList",
            success: function (func) {
                let w = jQuery.parseJSON(func)
                console.log(w);
                let tablehtml = "<table class=table table-bordered> <tr><th>Yazar ID</th><th>Yazar Adı</th></tr>";
                $.each(w, (index, value) => {
                    tablehtml += `<tr><td>${value.id}</td><td>${value.name}</td></tr>`
                });
                tablehtml += "</table>";
                $("#writerlist").html(tablehtml);

            }
        });
    });

![image](https://user-images.githubusercontent.com/64663453/188270671-057924e4-6feb-4a36-b061-193186245f7c.png)
<br/>
<h2>ID numarasına göre listeleme işlemi</h2>
 <p>id numarasını girdiğimiz veriyi aşağıdaki ajax komutuyla console ve arayüzde listeleme işlemi yapıyoruz</p>

    $("#btngetbyid").click(x => {
        let id = $("#wrid").val();
        $.ajax({
            contentType: "application/json",
            dataType: "json",
            type: "GET",
            url: "/Admin/Writer/GetWriterByID/",
            data: { wrid: id },
            success: function (func1) {
                let w = jQuery.parseJSON(func1);
                console.log(w);

                let getValue = `<table class=table table-bordered> <tr><th>Yazar ID</th><th>Yazar Adı</th></tr> <tr><td>${w.id}</td><td>${w.name}</td></tr></table>`
                $("#writerget").html(getValue);

            }
        });

    });

![image](https://user-images.githubusercontent.com/64663453/188270738-195b2e53-ba84-48ee-bd7c-beb135db45bb.png)
<br/>
<h2>Ekleme İşlemi</h2>
<p>Ajax ile veri ekleme işlemini aşağıdaki kod sayesinde gerçekleştiriyoruz</p>

    $("#btnaddwriter").click(function () {
        let writer = {
            id: $("#txtwriterid").val(),
            name: $("#txtwritername").val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Writer/AddWriter/",
            data: writer,
            success: function (func) {
                let result = jQuery.parseJSON(func);
                alert("yazar ekleme işlemi başarılı bir şekilde gerçekleşti");
            }
        });
    });

![image](https://user-images.githubusercontent.com/64663453/188270801-243fc4c1-c4d8-4f70-a436-a4082d344ea4.png)
![image](https://user-images.githubusercontent.com/64663453/188270813-95d51fd4-5ed3-4040-8814-c0b4de75baca.png)
<br/>
<h2>Silme İşlemi</h2>
<p>Aşağıdaki ajax komutları iie id numarasına göre silme işlemi gerçekleştiriyoruz</p>

    $("#btndeletewriter").click(x => {
        let id = $("#txtid").val();

        $.ajax({
            url: "/Admin/Writer/DeleteWriter/" + id,
            type: "POST",
            dataType: "json",
            success: function (func) {
                alert("yazar silme işlemi başarılı bir şekilde gerçekleşti");
            }
        });

    });

![image](https://user-images.githubusercontent.com/64663453/188271018-1713ff23-1a6e-42bf-a88e-8109bcb5901c.png)
![image](https://user-images.githubusercontent.com/64663453/188271022-f3b1420d-cb62-4176-84a2-b81e3dd9648f.png)
<br/>
<h2>Güncelleme işlemi</h2>
<p>Aşağıdaki ajax komutları ile güncelleme işlemleri gerçekleştiriyoruz</p>

    $("#btnupdatewriter").click(function () {
        let writer = {
            id: $("#txtupid").val(),
            name: $("#txtupname").val()
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Writer/UpdateWriter",
            data: writer,
            success: function (func) {
                alert("Güncelleme işlemi tamamlandı")
            }
        });
    });

![image](https://user-images.githubusercontent.com/64663453/188271079-cf48fe6a-0c5e-4387-adbe-742ef2a36229.png)
![image](https://user-images.githubusercontent.com/64663453/188271085-f11b617c-dd0d-4846-ba4f-11ee7ff5915f.png)


