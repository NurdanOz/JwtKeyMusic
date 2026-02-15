# 🎵 JwtKeyMusic - AI Destekli Müzik Keşif Platformu

[![.NET Core](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=.net)](https://dotnet.microsoft.com/)
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
* [🔒 Güvenlik ve Yetkilendirme](#-güvenlik-ve-yetkilendirme)
* [📸 Ekran Görüntüleri](#-ekran-görüntüleri)

---

## ✨ Öne Çıkan Özellikler

### 🎭 Ruh Haline Göre Müzik Keşfi
Gemini AI ile güçlendirilmiş akıllı asistan, kullanıcının ruh halini analiz ederek kişiselleştirilmiş müzik önerileri sunar.

> *"Bugün kendimi enerjik ama biraz melankolik hissediyorum"* → Sistem, veritabanındaki şarkıları analiz ederek mükemmel bir çalma listesi oluşturur.

### 🔐 Güvenli ve Ölçeklenebilir Mimari
- JWT tabanlı token kimlik doğrulama
- Role-based access control (RBAC)
- BCrypt ile güvenli şifreleme
- N-Katmanlı mimari ile sürdürülebilir kod yapısı

### 🎵 Kapsamlı Müzik Yönetimi
- Şarkı ekleme, düzenleme ve silme
- Çalma listeleri oluşturma
- Favori şarkılar
- Trend şarkılar ve keşfet sayfası

---

## 🚀 Kurulum ve Başlangıç

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
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
├── 📦 JwtKeyMusic (Ana Proje)
│
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
```

---

## 🎯 Temel Özellikler

### 👤 Kullanıcı Yönetimi
- ✅ Kayıt ve Giriş
- ✅ Profil Güncelleme
- ✅ Şifre Sıfırlama
- ✅ JWT Token ile Oturum Yönetimi

### 🎵 Müzik Özellikleri
- ✅ Şarkı Arama ve Filtreleme
- ✅ Kategori Bazlı Listeleme
- ✅ Trend Şarkılar
- ✅ Son Eklenenler
- ✅ Favori Şarkılar

### 📝 Çalma Listeleri
- ✅ Özel Çalma Listeleri Oluşturma
- ✅ Şarkı Ekleme/Çıkarma
- ✅ Liste Paylaşımı
- ✅ Sıralama ve Düzenleme

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
Kullanıcı: "Enerjik ama melankolik şarkılar istiyorum"
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
| 🧱 Framework | **.NET 8.0** | Yüksek performanslı Web API geliştirme |
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

## 🔒 Güvenlik ve Yetkilendirme

### Yetkilendirme Matrisi

| İşlem | Ziyaretçi | Kullanıcı | Admin |
|-------|-----------|-----------|-------|
| API Erişimi | ❌ 401 | ✅ | ✅ |
| Şarkı Dinleme | ❌ | ✅ | ✅ |
| Playlist Oluşturma | ❌ | ✅ | ✅ |
| Şarkı Ekleme | ❌ | ❌ | ✅ |
| Kullanıcı Yönetimi | ❌ | ❌ | ✅ |
| Sistem Ayarları | ❌ | ❌ | ✅ |

### Güvenlik Özellikleri

- 🔒 **JWT Token Authentication:** Her API isteği token ile doğrulanır
- 🔑 **BCrypt Password Hashing:** Şifreler güvenli bir şekilde hashlenmiştir
- 🛡️ **Role-Based Access Control:** Kullanıcı rolleri ile yetkilendirme
- 🚫 **CORS Policy:** Güvenli API erişimi
- ✅ **Input Validation:** Tüm inputlar doğrulanır

---

## 📸 Ekran Görüntüleri

### 🏠 Ana Sayfa
*Trend şarkılar ve keşfet bölümü*

### 🎭 Gemini AI Asistan
*Ruh haline göre müzik önerisi alan kullanıcı arayüzü*

### 📝 Çalma Listeleri
*Kullanıcının oluşturduğu özel çalma listeleri*

### ⚙️ Admin Paneli
*Şarkı yönetimi ve kullanıcı istatistikleri*

---

## 🤝 Katkıda Bulunma

Bu projeye katkıda bulunmak isterseniz:

1. Projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

---

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakabilirsiniz.

---

## 👨‍💻 Geliştirici

**[Adınız Soyadınız]**

- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [linkedin.com/in/yourprofile](https://linkedin.com/in/yourprofile)
- Email: your.email@example.com

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
