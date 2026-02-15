# 🎵 JwtKeyMusic - AI Destekli Müzik Keşif Platformu

[![.NET Core](https://img.shields.io/badge/.NET-6.0-purple?style=for-the-badge&logo=.net)](https://dotnet.microsoft.com/)
[![Gemini AI](https://img.shields.io/badge/Gemini-AI-4285F4?style=for-the-badge&logo=google)](https://ai.google.dev/)
[![JWT](https://img.shields.io/badge/JWT-Auth-000000?style=for-the-badge&logo=jsonwebtokens)](https://jwt.io/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)

**JwtKeyMusic**, kullanıcıların ruh hallerine göre müzik keşfedebildiği, **Gemini AI** destekli akıllı öneri sistemiyle donatılmış, **N-Katmanlı mimari** ile geliştirilmiş modern bir müzik platformudur.

Proje; **Clean Architecture**, **SOLID** prensipleri ve **RESTful API** standartları gözetilerek geliştirilmiştir.

---

## 📋 İçindekiler

* [✨ Öne Çıkan Özellikler](#-öne-çıkan-özellikler)
* [🚀 Kurulum ve Başlangıç](#-kurulum-ve-başlangıç)
* [🏗️ Proje Yapısı](#️-proje-yapısı)
* [🎯 Temel Özellikler](#-temel-özellikler)
* [🧠 Gemini AI Entegrasyonu](#-gemini-ai-entegrasyonu)
* [🛠️ Teknoloji Yığını](#️-teknoloji-yığını)
* [📸 Ekran Görüntüleri](#-ekran-görüntüleri)

---

## ✨ Öne Çıkan Özellikler

### 🎭 Ruh Haline Göre Müzik Keşfi
Gemini AI ile güçlendirilmiş akıllı asistan, kullanıcının ruh halini analiz ederek kişiselleştirilmiş müzik önerileri sunar.

> *"Bugün kendimi enerjik ama biraz da melankolik hissediyorum"* → Sistem, veritabanındaki şarkıları analiz ederek mükemmel bir çalma listesi oluşturur.

### 🔐 Güvenli ve Ölçeklenebilir Mimari
- JWT tabanlı token kimlik doğrulama
- Role-based access control (RBAC)
- BCrypt ile güvenli şifreleme
- N-Katmanlı mimari ile sürdürülebilir kod yapısı

---

## 🚀 Kurulum ve Başlangıç

### Gereksinimler

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/sql-server) (veya SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya JetBrains Rider

### Kurulum Adımları

#### 1. Projeyi Klonlayın
```bash
git clone https://github.com/[KULLANICI_ADINIZ]/JwtKeyMusic.git
cd JwtKeyMusic
```

#### 2. Veritabanı Bağlantısını Yapılandırın

`appsettings.json` dosyasını açın ve bağlantı dizesini güncelleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=JwtKeyMusicDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

#### 3. Gemini AI API Key'i Ekleyin

```json
{
  "GeminiAI": {
    "ApiKey": "YOUR_GEMINI_API_KEY_HERE",
    "Model": "gemini-1.5-flash"
  }
}
```

> **Not:** Gemini API key'i için [Google AI Studio](https://ai.google.dev/) adresinden ücretsiz anahtar alabilirsiniz.

#### 4. Migration'ları Çalıştırın

```bash
cd JwtKeyMusic.DataAccess
dotnet ef database update
```

#### 5. Projeyi Çalıştırın

```bash
dotnet run --project JwtKeyMusic.WebApi
```

API Swagger dokümantasyonu: `https://localhost:5001/swagger`

---

## 🏗️ Proje Yapısı

```
JwtKeyMusic/
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
├── 🖥️ JwtKeyMusic.UI                # MVC Frontend
│
└── 🌐 JwtKeyMusic.WebApi            # Web API Katmanı
    ├── Controllers/
    ├── Middlewares/
    └── Program.cs
```

---

## 🎯 Temel Özellikler

### 👤 Kullanıcı Yönetimi
- ✅ Kayıt ve Giriş
- ✅ Profil Güncelleme
- ✅ Şifre Sıfırlama
- ✅ JWT Token ile Oturum Yönetimi


### 🎭 Gemini AI Özellikleri
- ✅ Ruh Haline Göre Müzik Önerisi
- ✅ Doğal Dil İşleme
- ✅ Akıllı Playlist Oluşturma
- ✅ Müzik Analizi ve Eşleştirme

---

## 🧠 Gemini AI Entegrasyonu

### Nasıl Çalışır?

JwtKeyMusic, Google'ın **Gemini 1.5 Flash** modelini kullanarak kullanıcı taleplerini doğal dil işleme ile analiz eder.

### Örnek Kullanım:

```
Kullanıcı: "Enerjik şarkılar istiyorum"
```

### AI Süreci:
1. Gemini, kullanıcının ruh halini analiz eder
2. Veritabanındaki şarkıları kategorilere göre filtreler
3. Tempo, mod, enerji seviyesi gibi kriterleri değerlendirir
4. Kişiselleştirilmiş bir çalma listesi oluşturur

### Teknik Detaylar:
```csharp
public class GeminiAIService
{
    private readonly string _apiKey;
    private readonly string _model = "gemini-1.5-flash";
    
    public async Task<List<MusicDto>> GetMoodBasedRecommendations(string mood)
    {
        // Gemini AI'a kullanıcının ruh hali gönderilir
        var prompt = $"Kullanıcının ruh hali: {mood}. Uygun şarkı türlerini ve özelliklerini öner.";
        
        // AI'dan gelen öneriler veritabanı ile eşleştirilir
        var recommendations = await CallGeminiAPI(prompt);
        
        return await MatchSongsWithDatabase(recommendations);
    }
}
```

---

## 🛠️ Teknoloji Yığını

### Backend

| Kategori | Teknoloji | Kullanım Amacı |
|----------|-----------|----------------|
| 🧱 Framework | **.NET 6.0** | Yüksek performanslı Web API geliştirme |
| 🧠 AI/ML | **Google Gemini AI** | Akıllı müzik önerileri ve ruh hali analizi |
| 🗃️ ORM | **Entity Framework Core** | Veritabanı işlemleri ve migration yönetimi |
| 🔐 Güvenlik | **BCrypt.Net-Next** | Parola hashleme ve güvenli kimlik doğrulama |
| 🪪 Auth | **JWT** | Token bazlı kimlik doğrulama |
| 📊 Database | **SQL Server** | İlişkisel veritabanı yönetimi |

### Frontend (Opsiyonel)

- **ASP.NET Core MVC**
- **Bootstrap 5**
- **jQuery**
- **Font Awesome**

### Mimari Desenler

- ✅ **N-Layer Architecture**
- ✅ **Repository Pattern**
- ✅ **Dependency Injection**
- ✅ **DTO Pattern**
- ✅ **SOLID Principles**

---

### Güvenlik Özellikleri

- 🔒 **JWT Token Authentication:** Her API isteği token ile doğrulanır
- 🔑 **BCrypt Password Hashing:** Şifreler güvenli bir şekilde hashlenmiştir
- 🛡️ **Role-Based Access Control:** Kullanıcı rolleri ile yetkilendirme
- 🚫 **CORS Policy:** Güvenli API erişimi
- ✅ **Input Validation:** Tüm inputlar doğrulanır

---

## 📸 Ekran Görüntüleri

<img width="1172" height="2271" alt="BEPOP14" src="https://github.com/user-attachments/assets/ee02f9b6-fffe-4564-b647-854f5ff4256f" />
<img width="1920" height="1014" alt="BEPOP1" src="https://github.com/user-attachments/assets/7c8dd2b3-479d-4403-8a02-3c3f1f70acda" />
<img width="1920" height="1004" alt="BEPOP2" src="https://github.com/user-attachments/assets/be38fa05-0cc8-4bf7-9b2c-10a71371f3b1" />
<img width="1920" height="1011" alt="BEPOP3" src="https://github.com/user-attachments/assets/845a4922-a682-4653-9a24-f15711a8858f" />
<img width="1920" height="1014" alt="BEPOP4" src="https://github.com/user-attachments/assets/a840def8-bc83-4e4d-96fa-6196e2c8476c" />
<img width="1920" height="1014" alt="BEPOP5" src="https://github.com/user-attachments/assets/1409d0b4-7733-41d8-ae9a-91dbb6930e74" />
<img width="1920" height="1021" alt="BEPOP6" src="https://github.com/user-attachments/assets/6968cffd-605d-4d43-9bf9-5464820f9d40" />
<img width="1920" height="1017" alt="BEPOP7" src="https://github.com/user-attachments/assets/6c8d2552-5923-4064-81fd-e21151660b33" />
<img width="1920" height="1007" alt="BEPOP8" src="https://github.com/user-attachments/assets/fbf7893a-8b0e-488b-9df0-710f42ac0578" />
<img width="1920" height="1021" alt="BEPOP9" src="https://github.com/user-attachments/assets/f71dbf9e-465e-4c16-a185-67f446624737" />
<img width="1920" height="1018" alt="BEPOP10" src="https://github.com/user-attachments/assets/7825c1a7-bfbf-49d7-ba8b-5e5fd9e175e0" />
<img width="1920" height="1014" alt="BEPOP11" src="https://github.com/user-attachments/assets/07c05530-d987-4ff6-9282-6f95fbd4cfb2" />
<img width="1920" height="1014" alt="BEPOP12" src="https://github.com/user-attachments/assets/e0c7efea-f206-4160-a1fa-b282ec354782" />
<img width="1920" height="1028" alt="BEPOP13" src="https://github.com/user-attachments/assets/fe7ce8e2-2402-4d33-a496-78d271cf28be" />


---

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakabilirsiniz.

---

## 🙏 Teşekkürler

- Google Gemini AI ekibine yapay zeka desteği için
- .NET topluluğuna sürekli geliştirme ve destek için
- Tüm açık kaynak katkıda bulunanlara

---

## 📚 Kaynaklar

- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [Gemini AI Documentation](https://ai.google.dev/docs)
- [JWT.io](https://jwt.io/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)

---

**⭐ Projeyi beğendiyseniz yıldız vermeyi unutmayın!**
