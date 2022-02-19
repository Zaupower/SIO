
export const purchasingChartData = {
    type: "line",
    data: {
      labels: ['Janeiro',
      'Fevereiro',
      'Março',
      'Abril',
      'Maio',
      'Junho',
      'Julho',
      'Agosto',
      'Setembro',
      'Outubro',
      'Novembro',
      'Dezembro'],
      datasets: [
        
        {
          label: "Planetary Mass (relative to the Sun x 10^-6)",
          data: [0.166, 2.081, 3.003, 0.323, 954.792, 285.886, 43.662, 51.514],
          backgroundColor: "rgba(71, 183,132,.5)",
          borderColor: "#47b784",
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
  
  export default purchasingChartData;