<template>
    <div>
      <h1 class="m-4">CEO</h1>
      <div class="info-values">
      <h5>Total de compras da empresa relativas a um ano: {{total_despesas}}€</h5>
      <h5>Total de vendas relativas a um ano: {{total_lucros}}€</h5>
      <h5>Margem Bruta relativa a um ano: {{total}}€</h5>
      </div>

        <div class="dropdown">

            <span class="label">Escolher ano</span>
            <select
            v-model="selected_ano_Total"
            class="dropdown-content"
            @change="getChartData(selected_ano_Total)"
            >
            
            <option value="2018">2018</option>
            <option value="2019">2019</option>
            <option value="2020">2020</option>
            <option value="2021">2021</option>
            
            </select>
        </div>
      <div class="chart-container">
        <canvas id="planet-chart"></canvas>
      </div>
       
    </div>
</template>

<script>
import Chart from 'chart.js'
import planetChartData from '../planet-data-ceo.js'
export default {
    name: 'PlanetChart',
    data () {
    return {
      planetChartData: planetChartData,
      selected_ano_Total: new Date().getFullYear(),
      total_despesas: 0,
      total_lucros: 0,
      total:0
    }
  },
async mounted () {
    const anoCurrente = new Date().getFullYear()
    var despesas = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    var lucros = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    this.planetChartData.data.labels = [
                  'Janeiro',
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
                  'Dezembro'
                ]

    const totalDespesas  =
     await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + anoCurrente)

    const totalDespesasRes  = await totalDespesas.json();
    this.total_despesas = totalDespesasRes
    console.log(totalDespesasRes)
    const res =
     await fetch('https://localhost:44381/api/Despesas/DespesasPorMes_Ano?ano=' + anoCurrente)
    const results = await res.json()

    //Update lucros
    //Update Totalucros 
      const totalVendas  =
      await fetch('https://localhost:44381/api/Vendas/Total_Ano?ano=' +anoCurrente)

      const totalVendasRes  = await totalVendas.json();
      this.total_lucros = totalVendasRes
      console.log(totalVendasRes)
      let tmpValue = parseFloat(this.total_lucros)-parseFloat(this.total_despesas);
      
      this.total=Math.round(tmpValue * 100) / 100

    for (let i = 0; i < results.length; i++) {
      despesas[results[i].mes - 1] = results[i].valor
    }
    this.planetChartData.data.datasets[0].data = despesas
    this.planetChartData.data.datasets[0].label = anoCurrente
    const ctx = document.getElementById('planet-chart')
    new Chart(ctx, this.planetChartData)
  },
  methods: {
      async getChartData (ano) {
      var despesas = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
      var lucros = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

      //Update TotalDespesas
      const totalDespesas  =
      await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + ano)

      const totalDespesasRes  = await totalDespesas.json();
      console.log(totalDespesasRes)
      this.total_despesas = totalDespesasRes

      //Update Totalucros 
      const totalVendas  =
      await fetch('https://localhost:44381/api/Vendas/Total_Ano?ano=' +ano)

      const totalVendasRes  = await totalVendas.json();
      this.total_lucros = totalVendasRes

      const res = await fetch('https://localhost:44381/api/Despesas/DespesasPorMes_Ano?ano=' + ano)
      const results = await res.json()

      //Update total
      this.total=parseFloat(this.total_lucros)-parseFloat(this.total_despesas);

      //Update Chart
      for (let i = 0; i < results.length; i++) {
          despesas[results[i].mes - 1] = results[i].valor
          console.log(results[i].mes - 1)
      }
      this.planetChartData.data.datasets[0].data = despesas
      this.planetChartData.data.datasets[0].label = ano
      const ctx = document.getElementById('planet-chart')
      new Chart(ctx, this.planetChartData)
    }
  }
}
</script>

<style scoped>
.chart-container {
    width: 70%;
    height:70%;
    padding-left: 80px;
}

.info-values{
  text-align: left;
  padding-left: 80px;

}

.dropdown {
  position: relative;
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  padding: 12px 16px;
  z-index: 1;
}

.dropdown:hover .dropdown-content {
  display: block;
}

</style>