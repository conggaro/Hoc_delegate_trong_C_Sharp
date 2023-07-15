// kiểu delegate là kiểu ủy quyền
// delegate là kiểu (type)

// nó được dùng để tạo ra biến
// biến này sẽ tham chiếu đến 1 cái hàm khác

// hay nói cách khác
// có thể lấy 1 hàm rồi đem gán cho biến delegate

// có thể sử dụng biến kiểu delegate
// để thi hành các hàm đang được lưu trong biến delegate đó

// nếu các bạn học C++
// thì biến kiểu delegate khá giống con trỏ

// có thể khai báo biến delegate trong namespace
// hoặc khai báo biến kiểu delegate trong class

using System;

namespace MyApp{
    // tạo biến kiểu delegate
    // người ta dùng biến kiểu delegate như 1 kiểu dữ liệu
    public delegate void ThongBao(string data);         // Có thể dùng Action ở trong thư viện .NET, để đỡ phải viết dài như này

    public delegate int ThongBao_Int();                 // Có thể dùng Func ở trong thư viện .NET, để đỡ phải viết dài như này

    public class Program{
        // tạo 1 hàm
        // trông nó tương đồng với biến ThongBao
        // giống nhau kiểu trả về là void
        // giống nhau cùng nhận tham số kiểu string
        public static void HienThi(string data){
            // thiết lập màu
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.Write($"{data}");

            // xóa màu
            Console.ResetColor();
        }

        public static void CanhBao(string data){
            // thiết lập màu
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.Write($"{data}");

            // xóa màu
            Console.ResetColor();
        }

        // cái TinhTong này dùng để gán cho Func<int, int, string> bien8
        public static string TinhTong(int thamSo1, int thamSo2){
            int tong = thamSo1 + thamSo2;
            
            return tong.ToString();
        }

        // tạo hàm hiển thị ra chữ màu vàng, nền xám
        public static void Ham_ChuVang_NenXam(string str){
            // thiết lập màu nền xám
            Console.BackgroundColor = ConsoleColor.Gray;

            // thiết lập màu chữ vàng
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(str);

            // xóa thiết lập màu
            // để màu nó về mặc định
            Console.ResetColor();
        }

        // hàm tính hiệu
        // hàm này đặc biệt ở chỗ
        // là cho truyền vào 1 hàm như 1 tham số
        public static void TinhHieu(int thamSo1, int thamSo2, Action<string> thamSo_ham){
            int hieu = thamSo1 - thamSo2;

            string str = hieu.ToString();
            
            if(thamSo_ham != null){
                thamSo_ham(str);
            }
        }

        public static void Main(string[] args){
            // kiểu dữ liệu thông báo
            // biến_1 có kiểu dữ liệu ThongBao
            // mà kiểu delegate là kiểu tham chiếu
            // nên có thể gán null cho biến_1
            ThongBao bien1 = HienThi;

            // để thi hành những dòng lệnh lưu bên trong
            // biến kiểu delegate
            
            // cách 1:
            // đây là 1 cách thực thi
            bien1(" Welcome Boss ");

            // cách 2:
            // dùng phương thức Invoke
            // Invoke tiếng Anh nghĩa là gọi
            Console.Write($"\n");
            bien1?.Invoke(" Oh! Boss ");

            // biến delegate có thể tham chiếu
            // đến nhiều phương thức 1 lúc
            
            // tức là nó tạo ra một chuỗi tham chiếu
            // để tạo ra 1 chuỗi tham chiếu
            // thì sử dụng toán tử +=

            ThongBao bien2 = null;

            bien2 += HienThi;               // đây là tạo ra chuỗi tham chiếu
            Console.Write($"\n\n");
            if (bien2 != null)
            {
                bien2("Color green");
            }
            bien2 -= HienThi;               // đây là xóa bớt 1 tham chiếu

            bien2 += CanhBao;               // đây là tạo ra chuỗi tham chiếu
            Console.Write($"\n");
            bien2?.Invoke("Color red");     // Invoke tiếng Anh là gọi

            // Thư viện .NET đã tạo sẵn
            // cho chúng ta biến kiểu delegate
            // đó là Action và Func
            
            // nó trông kiểu kiểu như này này
            // ví dụ thôi
            // public delegate void Action();
            // public delegate void Func(string data);

            // nếu bạn muốn tạo ra biến_3
            // kiểu delegate
            // kiểu trả về là void
            // không tham số
            // thì khuyên bạn nên dùng Action được tạo sẵn bởi .NET
            // public delegate void Action();
            Action bien3 = null;

            // thật ra Action
            // nó bản chất là kiểu trả về void
            // bạn có thể thêm tham số nhé
            Action<string, int> bien4 = null;       // tương đương với public delegate void Action(string s, int n);
            
            // nếu bạn muốn dùng Action
            // để hứng cái hàm HienThi và CanhBao
            // thì viết code như này
            Action<string> bien5 = null;
            bien5 += HienThi;
            bien5 += CanhBao;           // nó sẽ nối chuỗi tham chiếu từ null, lên đến HienThi, rồi lên đến CanhBao

            Console.Write($"\n\n");
            bien5?.Invoke("Day la bien 5");

            // Tiếp theo là sử dụng Func
            // để khai báo ra các biến delegate
            
            // cái Func khác Action ở chỗ
            // nó phải có kiểu trả về (cái Action thì nó mặc định là void)
            // ví dụ:
            Func<int> bien6 = null;       // tương đương với public delegate int Func(); --> từ đấy thì mới có Func để mà dùng

            // nếu bạn muốn dùng Func
            // kiểu trả về string
            // tham số 1 là int
            // tham số 2 là int
            
            // Func<kiểu_của_tham_số_1, kiểu_của_tham_số_2, kiểu_trả_về>
            // cái tham số cuối cùng mới là kiểu_trả_về

            // thì viết như này
            Func<int, int, string> bien7 = null;     // tương đương với public delegate string Func(int thamSo1, int thamSo2);

            // ví dụ Func nữa
            Func<int, int, string> bien8 = TinhTong;
            Console.Write($"\n\n");
            Console.Write(bien8(10, 15));

            
            // Có 1 cái cách viết nữa
            // đó là truyền hàm vào 1 hàm khác
            // như 1 tham số

            // ví dụ
            // tôi muốn tạo 1 cái biến_9 (dùng để hứng 1 cái hàm)
            // kiểu trả về là void (tức là tôi đang làm cái hiển thị ra màn hình console)
            // tham số 1 có kiểu int
            // tham số 2 có kiểu int
            // tham số 3 là 1 hàm (hàm đấy có kiểu trả về void)
            Action<int, int, Action<string>> bien9 = TinhHieu;

            // thực thi biến_9
            Console.Write($"\n\n");
            if(bien9 != null){
                bien9(100, 10, Ham_ChuVang_NenXam);     // in ra 90 có màu vàng, nền xám
            }
        }
    }
}