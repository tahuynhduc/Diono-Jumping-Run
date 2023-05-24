using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LeaderboardManager : MonoBehaviour
{
public string leaderboardId = "my_leaderboard";

    // Start is called before the first frame update
    void Start()
    {
        // Kiểm tra xem người chơi đã được xác thực với hệ thống xã hội chưa
        if (Social.localUser.authenticated && Social.localUser.state == UserState.Online)
        {
            // Load danh sách điểm cao từ leaderboard
            Social.LoadScores(leaderboardId, OnScoresLoaded);
        }
        else
        {
            Debug.LogWarning("Người chơi chưa được xác thực hoặc không kết nối internet. Không thể tải danh sách điểm cao.");
        }
    }

    // Hàm callback được gọi khi danh sách điểm cao đã được tải
    void OnScoresLoaded(IScore[] scores)
    {
        if (scores != null && scores.Length > 0)
        {
            // Hiển thị danh sách điểm cao
            for (int i = 0; i < scores.Length; i++)
            {
                Debug.Log("Hạng " + (i + 1) + ": " + scores[i].userID + " - " + scores[i].value);
            }
        }
        else
        {
            Debug.Log("Không tìm thấy điểm cao nào.");
        }
    }
}