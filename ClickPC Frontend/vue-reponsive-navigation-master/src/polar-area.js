
export const planetChartData3 = {
  type: "bar",
  data: {
    labels: ["Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"],
    
    datasets: [
      
      {
        label: "Planetary Mass (relative to the Sun x 10^-6)",
        data: [0.166, 2.081, 3.003, 0.323, 954.792, 285.886, 43.662, 51.514],
        backgroundColor: [
          "rgba(255, 0, 0, 0.5)",
          "rgba(255, 165, 0, 0.5)",
          "rgba(255, 206, 86, 0.5)",
          "rgba(255, 255, 0, 0.5)",
          "rgba(0, 128, 0, 0.5)",
          "rgba(0, 0, 255, 0.5)",
          "rgba(75, 0, 130, 0.5)",
          "rgba(238, 130, 238, 0.5)",
          "rgba(255, 206, 86, 0.5)"
        ],
        borderColor: [
          "rgba(255, 0, 0, 0.5)",
          "rgba(255, 165, 0, 0.5)",
          "rgba(255, 206, 86, 0.5)",
          "rgba(255, 255, 0, 0.5)",
          "rgba(0, 128, 0, 0.5)",
          "rgba(0, 0, 255, 0.5)",
          "rgba(75, 0, 130, 0.5)",
          "rgba(238, 130, 238, 0.5)",
          "rgba(255, 206, 86, 0.5)"
        ],
        borderWidth: 2
      }
    ]
  },
  options: {
    responsive: true,
    lineTension: 10,
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
            padding: 25
          }
        }
      ]
    }
  }
};

export default planetChartData3;