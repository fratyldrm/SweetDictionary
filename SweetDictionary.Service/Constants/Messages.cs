namespace SweetDictionary.Service.Constants;

public static class Messages
{
    // Success Messages
    public const string PostAddMessage = "Post başarıyla eklendi.";
    public const string PostUpdateMessage = "Post başarıyla güncellendi.";
    public const string PostDeleteMessage = "Post başarıyla silindi.";
    public const string PostsListedMessage = "Tüm postlar başarıyla listelendi.";
    public const string PostsListedByAuthorMessage = "Yazara ait tüm postlar başarıyla listelendi.";
    public const string PostsListedByCategoryMessage = "Kategoriye ait tüm postlar başarıyla listelendi.";
    public const string PostsListedByTitleMessage = "Aranan başlığı içeren postlar başarıyla listelendi.";
    public const string PostRetrievedMessage = "İlgili post başarıyla getirildi.";

    // Error Messages
    public static string PostIsPresentMessage(Guid id) => $"İlgili id: {id} ile post bulunamadı.";
    public const string PostAddFailedMessage = "Post eklenirken bir hata oluştu.";
    public const string PostUpdateFailedMessage = "Post güncellenirken bir hata oluştu.";
    public const string PostDeleteFailedMessage = "Post silinirken bir hata oluştu.";
    public const string PostsListFailedMessage = "Postlar listelenirken bir hata oluştu.";
    public const string PostsListByAuthorFailedMessage = "Yazara ait postlar listelenirken bir hata oluştu.";
    public const string PostsListByCategoryFailedMessage = "Kategoriye ait postlar listelenirken bir hata oluştu.";
    public const string PostsListByTitleFailedMessage = "Başlığa göre postlar listelenirken bir hata oluştu.";
    public const string PostRetrieveFailedMessage = "Post getirilemedi.";

    // Validation Messages
    public const string InvalidAuthorIdMessage = "Geçersiz yazar ID.";
    public const string InvalidCategoryIdMessage = "Geçersiz kategori ID.";
    public const string InvalidTitleSearchMessage = "Arama yapılacak başlık metni geçerli değil.";
}
