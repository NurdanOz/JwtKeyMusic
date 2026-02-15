🎵 Bepop - AI Destekli Müzik Keşif Platformu
Show Image
Show Image
Show Image
Show Image
Bepop, kullanıcıların ruh hallerine göre müzik keşfedebildiği, Gemini AI destekli akıllı öneri sistemiyle donatılmış, N-Katmanlı mimari ile geliştirilmiş modern bir müzik platformudur.
Proje; Clean Architecture, SOLID prensipleri ve RESTful API standartları gözetilerek geliştirilmiştir.



✨ Öne Çıkan Özellikler
🎭 Ruh Haline Göre Müzik Keşfi
Gemini AI ile güçlendirilmiş akıllı asistan, kullanıcının ruh halini analiz ederek kişiselleştirilmiş müzik önerileri sunar.
"Bugün kendimi enerjik ama biraz melankolik hissediyorum" → Sistem, veritabanındaki şarkıları analiz ederek mükemmel bir çalma listesi oluşturur.

🔐 Güvenli ve Ölçeklenebilir Mimari

JWT tabanlı token kimlik doğrulama
Role-based access control (RBAC)
BCrypt ile güvenli şifreleme
N-Katmanlı mimari ile sürdürülebilir kod yapısı


🏗️ Proje Yapısı

├── 💼 JwtKeyMusic.Business          # İş Mantığı Katmanı
│   ├── Abstract/                    # Interface'ler
│   ├── Concrete/                    # Servis Implementasyonları
│   └── Services/
│       └── GeminiAIService.cs       # Gemini AI Entegrasyonu
│
├── 🗃️ JwtKeyMusic.DataAccess        # Veri Erişim Katmanı
│   ├── Abstract/                    # Repository Interface'leri
│   ├── Concrete/                    # Repository Implementasyonları
│   ├── Context/                     # DbContext
│   └── Migrations/                  # EF Core Migration'ları
│
├── 📋 JwtKeyMusic.DTO                # Data Transfer Objects
│   ├── MusicDtos/
│   ├── UserDtos/
│   └── PlaylistDtos/
│
├── 🏛️ JwtKeyMusic.Entities          # Domain Entity'leri
│   ├── Music.cs
│   ├── User.cs
│   ├── Playlist.cs
│   └── ...
│
├── 🖥️ JwtKeyMusic.UI                # MVC Frontend (Opsiyonel)
│
└── 🌐 JwtKeyMusic.WebApi            # Web API Katmanı
    ├── Controllers/
    ├── Middlewares/
    └── Program.cs

🎯 Temel Özellikler

👤 Kullanıcı Yönetimi

✅ Kayıt ve Giriş
✅ Profil Güncelleme
✅ Şifre Sıfırlama
✅ JWT Token ile Oturum Yönetimi


🎭 Gemini AI Özellikleri

✅ Ruh Haline Göre Müzik Önerisi
✅ Doğal Dil İşleme
✅ Akıllı Playlist Oluşturma
✅ Müzik Analizi ve Eşleştirme


🧠 Gemini AI Entegrasyonu

Nasıl Çalışır?
JwtKeyMusic, Google'ın Gemini 1.5 Flash modelini kullanarak kullanıcı taleplerini doğal dil işleme ile analiz eder.
Örnek Kullanım:
Kullanıcı: "Enerjik ama melankolik şarkılar istiyorum"
AI Süreci:

Gemini, kullanıcının ruh halini analiz eder
Veritabanındaki şarkıları kategorilere göre filtreler
Tempo, mod, enerji seviyesi gibi kriterleri değerlendirir
Kişiselleştirilmiş bir çalma listesi oluşturur


KategoriTeknolojiKullanım Amacı

🧱 Framework.NET 6.0 Yüksek performanslı Web API geliştirme
🧠 AI/MLGoogle Gemini AIAkıllı müzik önerileri ve ruh hali analizi
🗃️ ORMEntity Framework CoreVeritabanı işlemleri ve migration yönetimi
🔐 GüvenlikBCrypt.Net-NextParola hashleme ve güvenli kimlik doğrulama
🪪 AuthJWTToken bazlı kimlik doğrulama
📊 DatabaseSQL Serverİlişkisel veritabanı yönetimi

Frontend (Opsiyonel)
ASP.NET Core MVC
Bootstrap 5
jQuery
Font Awesome

Mimari Desenler

✅ N-Layer Architecture
✅ Repository Pattern
✅ Dependency Injection
✅ DTO Pattern
✅ SOLID Principles


🔒 JWT Token Authentication: Her API isteği token ile doğrulanır
🔑 BCrypt Password Hashing: Şifreler güvenli bir şekilde hashlenmiştir
🛡️ Role-Based Access Control: Kullanıcı rolleri ile yetkilendirme
🚫 CORS Policy: Güvenli API erişimi
✅ Input Validation: Tüm inputlar doğrulanır


📸 Ekran Görüntüleri

<img width="1172" height="2271" alt="BEPOP14" src="https://github.com/user-attachments/assets/ad4dfd3c-aada-4163-8566-c00a37712ffc" />
<img width="1920" height="1014" alt="BEPOP1" src="https://github.com/user-attachments/assets/66ef7603-c407-4c8f-840c-b8cb382d611b" />
<img width="1920" height="1004" alt="BEPOP2" src="https://github.com/user-attachments/assets/cef73d70-13e1-43e7-aeb1-556ac6cbc2a0" />
<img width="1920" height="1011" alt="BEPOP3" src="https://github.com/user-attachments/assets/bdf6340b-99b7-4d56-afb4-7697fcaa1b10" />
<img width="1920" height="1014" alt="BEPOP4" src="https://github.com/user-attachments/assets/0ecd152d-0166-4727-af00-470c0e790ee7" />
<img width="1920" height="1014" alt="BEPOP5" src="https://github.com/user-attachments/assets/3fe4fa44-3281-48ae-8845-8e824b162549" />
<img width="1920" height="1021" alt="BEPOP6" src="https://github.com/user-attachments/assets/398727a9-47cb-432a-8a33-a65e2de6e3e2" />
<img width="1920" height="1017" alt="BEPOP7" src="https://github.com/user-attachments/assets/739943f6-52b1-438a-a181-4095d023a555" />
<img width="1920" height="1007" alt="BEPOP8" src="https://github.com/user-attachments/assets/a69f8a8a-dd1d-4f9e-9923-4cf307ab3ef9" />
<img width="1920" height="1021" alt="BEPOP9" src="https://github.com/user-attachments/assets/df61ed8c-ca0a-4a68-b13c-4fa4207736b8" />
<img width="1920" height="1018" alt="BEPOP10" src="https://github.com/user-attachments/assets/9a465894-8c9a-416a-b2b6-b909c16a2533" />
<img width="1920" height="1014" alt="BEPOP11" src="https://github.com/user-attachments/assets/bfe2a906-0489-46a8-9f09-74ded0779b12" />
<img width="1920" height="1014" alt="BEPOP12" src="https://github.com/user-attachments/assets/b561869d-ce02-4646-9ac9-0132638d933b" />
<img width="1920" height="1028" alt="BEPOP13" src="https://github.com/user-attachments/assets/33af1fdc-1972-4b2c-9030-0efc7c1add0b" />


