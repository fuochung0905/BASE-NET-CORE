document.addEventListener("DOMContentLoaded", function () {
    let currentYear = new Date().getFullYear();
    let currentMonth = new Date().getMonth() + 1;

    document.getElementById("yearPicker").value = currentYear;
    document.querySelector(`.month-btn[data-month='${currentMonth}']`).classList.add("active");

    function getRandomColor() {
        let colors = ["#FF5733", "#33FF57", "#3357FF", "#F4A261", "#E76F51", "#2A9D8F", "#E9C46A"];
        return colors[Math.floor(Math.random() * colors.length)];
    }
    function loadChart(selectedMonth, selectedYear) {
        fetch(`/ThongKeKetQuaCongViec/GetKetQua?nam=${selectedYear}`)
            .then(response => response.json())
            .then(data => {
                let labels = data.map(d => d.NguoiThucHien);
                let values = selectedMonth === 0 ?
                    data.map(d => d.TongSoGioNam) :
                    data.map(d => d[`Thang${selectedMonth}`] || 0);
                

               

                let colors = labels.map(() => getRandomColor());

                let ctx = document.getElementById("monthlyChart").getContext("2d");

                if (window.myChart instanceof Chart) {
                    window.myChart.destroy();
                }

                window.myChart = new Chart(ctx, {
                    type: "bar",
                    data: {
                        labels: labels,
                        datasets: [{
                            label: `Thống kê ${selectedMonth === 0 ? "Cả Năm" : "Tháng " + selectedMonth}`,
                            backgroundColor: colors.map(color => `${color}80`),
                            borderColor: colors,
                            borderWidth: 2,
                            data: values
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            legend: { labels: { font: { size: 14 } } },
                            tooltip: {
                                callbacks: {
                                    label: function (tooltipItem) {
                                        return `${tooltipItem.raw.toFixed(2)} giờ`;
                                    }
                                }
                            }
                        },
                        scales: {
                            y: {
                                beginAtZero: true,
                                ticks: {
                                    callback: function (value) { return value.toFixed(2); }
                                }
                            }
                        }
                    }
                });
                let daysInMonth = new Date(selectedYear, selectedMonth, 0).getDate();
                let workDays = [...Array(daysInMonth)].filter((_, i) => {
                    let day = new Date(selectedYear, selectedMonth - 1, i + 1).getDay();
                    return day !== 0;
                }).length;
                let standardHours = workDays * 8;

                let belowAvgUsers = labels
                    .map((user, i) => ({
                        stt: i + 1,
                        user,
                        hours: values[i],
                        stars: getStarRating(values[i], standardHours)
                    }))
                    .filter(item => item.hours > 0 );

                let zeroUsers = labels.filter((_, i) => values[i] === 0);
                document.getElementById("zeroHours").innerHTML = zeroUsers.map(user => `<li>${user}</li>`).join('');
                document.getElementById("collapseZeroHours").classList.toggle("show", zeroUsers.length > 0);


                let tableBody = document.querySelector("#performanceTable tbody");
                tableBody.innerHTML = belowAvgUsers.map(item =>
                    `<tr>
                            <td>${item.stt}</td>
                            <td>${item.user}</td>
                            <td>${item.hours.toFixed(2)}</td>
                            <td>${item.stars}</td>
                        </tr>`).join("");
            })
            .catch(error => console.error("Lỗi khi lấy dữ liệu:", error));
    }

    function getStarRating(hours, standard) {
        let ratio = (hours / standard) * 100;
        if (ratio >= 100) return "⭐⭐⭐⭐⭐";
        if (ratio >= 90) return "⭐⭐⭐⭐";
        if (ratio >= 80) return "⭐⭐⭐";
        return "⭐⭐";
    }

    document.getElementById("exportPerformance").addEventListener("click", function () {
        let table = document.getElementById("performanceTable");
        let wb = XLSX.utils.book_new();
        let ws = XLSX.utils.table_to_sheet(table);
        XLSX.utils.book_append_sheet(wb, ws, "Hiệu suất");
        XLSX.writeFile(wb, "DanhGiaHieuSuat.xls");
    });
    loadChart(currentMonth, currentYear);
    
    document.querySelectorAll(".month-btn").forEach(item => {
        item.addEventListener("click", function () {
            document.querySelectorAll(".month-btn").forEach(el => el.classList.remove("active"));
            this.classList.add("active");
            loadChart(parseInt(this.getAttribute("data-month")), document.getElementById("yearPicker").value);
        });
    });

    document.getElementById("yearPicker").addEventListener("change", function () {
        loadChart(currentMonth, parseInt(this.value));
    });
    // Sự kiện khi thay đổi năm
    document.getElementById("yearPicker").addEventListener("change", function () {
        loadChart(parseInt(this.value));
    });


    // Xử lý sự kiện nút chuyển đổi chế độ xem
    document.getElementById("btnViewP").addEventListener("click", function () {
        window.location.href = "/ThongKeKetQuaCongViec/indexP";
    });
    document.getElementById("btnViewYear").addEventListener("click", function () {
        window.location.href = "/ThongKeKetQuaCongViec/indexY";
    });

    document.getElementById("btnViewWeek").addEventListener("click", function () {
        window.location.href = "/ThongKeKetQuaCongViec/indexT";
    });
});