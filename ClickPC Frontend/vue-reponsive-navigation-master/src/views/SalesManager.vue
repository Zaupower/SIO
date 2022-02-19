
/* eslint-disable */ 
<template>
  <div class="about">
    <h1>Sales Manager</h1>
    <div class="chart-container-align">
      <div class="chart-container">
        <div>
        <ejs-dropdownlist id='dropdownlist' v-model="selected_ano_Total" @change="getChartData(selected_ano_Total)" placeholder='Selecione um ano'  :dataSource='anos'></ejs-dropdownlist>
        
        <ejs-dropdownlist id='dropdownlist' v-model="selected_ano_Total2" @change="setSecundYear(selected_ano_Total2)" placeholder='Selecione segundo ano'  :dataSource='anos'></ejs-dropdownlist>
      </div>
        <h3>Vendas por mes</h3>
      <canvas id="planet-chart"></canvas>
      </div>
        <div class="chart-container">
            <h3>Top Compradores</h3>
            <canvas id="planet-chart2"></canvas>

            <h3>Faturas de vendas num mês</h3>
              <div class="control_wrapper">
               <ejs-dropdownlist id='dropdownlist3' placeholder='Selecione um mes' :dataSource='meses_select' :fields='fields'  v-model="mes_select" @change="onMonthSelected(mes_select)"></ejs-dropdownlist>
              </div>
              <div class="accordion">
                <ejs-accordion ref="accordionInc2">
                </ejs-accordion>
              </div>


            <h3>Faturas de um cliente</h3>

              <div class="control_wrapper">
                <ejs-dropdownlist id='dropdownlist' v-model="client" @change="onClientSelected(client)" placeholder='Selecione um cliente'  :dataSource='clientsData'></ejs-dropdownlist>
              </div>
                  <div class="accordion">
                    <ejs-accordion ref="accordionInc">
                    </ejs-accordion>
                  </div>
        </div>
      </div>
  </div>
  
</template>

<script>
import Chart from 'chart.js'
import planetChartData from '../planet-data.js'
import planetChartData2 from '../bar-chart.js'
import Vue from 'vue';
import { DropDownListPlugin } from "@syncfusion/ej2-vue-dropdowns";

import { AccordionPlugin } from '@syncfusion/ej2-vue-navigations';

Vue.use(AccordionPlugin);
Vue.use(DropDownListPlugin);
export default {
    name: 'PlanetChart',
    name2: 'PlanetChart2',
    name3: 'app',
    data () {
    return {
      selected_ano_Total: new Date().getFullYear(),
      dataSource : [],
      anos: [ new Date().getFullYear(), new Date().getFullYear()-1, new Date().getFullYear() - 2, new Date().getFullYear() - 3],
      clientsData: [],
      meses_select: [
      { Id: '0', Mes_select: 'Janeiro' },
      { Id: '1', Mes_select: 'Fevereiro' },
      { Id: '2', Mes_select: 'Março' },
      { Id: '3', Mes_select: 'Abril' },
      { Id: '4', Mes_select: 'Maio' },
      { Id: '5', Mes_select: 'Junho' },
      { Id: '6', Mes_select: 'Julho' },
      { Id: '7', Mes_select: 'Agosto' },
      { Id: '8', Mes_select: 'Setembro' },
      { Id: '9', Mes_select: 'Outubro' },
      { Id: '10', Mes_select: 'Novembro' },
      { Id: '11', Mes_select: 'Dezembro' },
    ],
    fields: { text: 'Mes_select', value: 'Id' },
      planetChartData: planetChartData,
      planetChartData2: planetChartData2,
    }
  },
  async mounted () {
    //Get total vendas 
    const currentYeir=  new Date().getFullYear()
    const vendas_total  =
      await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + currentYeir)
    const result_vendas_total  = await vendas_total.json();
    console.log("Rersult total vendas")
    console.log(result_vendas_total)

    //Get Vendas por mes
    var quantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    const vendas_por_mes  =
      await fetch('https://localhost:44381/api/Vendas/VendasPorMes_Ano?ano=' + currentYeir)
    const result_vendas_por_mes = await vendas_por_mes.json();
    console.log("quantidades")
    result_vendas_por_mes.forEach(element => {
      quantidades[element.mes - 1] = element.valor;
    });
    console.log(quantidades);

    //Get top clients
    var nomes = [];
    var quantidadesClients = [];

    const top_clientes  =
      await fetch('https://localhost:44381/api/Clientes/TopClientes_Ano?ano=' +currentYeir)
    const result_top_clientes  = await top_clientes.json();
    console.log("nomes quantidades")
    result_top_clientes.forEach(element => {
      nomes.push(element.nome);
      quantidadesClients.push(element.valor);
    });
    console.log(nomes)
    this.clientsData = nomes
   
    
    console.log(quantidadesClients)
    //Update Chart
    this.planetChartData2.type = 'line'
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
    this.planetChartData.data.datasets[0].data = quantidades
    this.planetChartData.data.datasets[0].label = currentYeir
    const ctx = document.getElementById('planet-chart')
    new Chart(ctx, this.planetChartData)

    //Plot 2 
    this.planetChartData2.type = 'bar'
    this.planetChartData2.options.scales.yAxes[0].ticks.padding = 5
    this.planetChartData2.data.labels =nomes
    this.planetChartData2.data.datasets[0].data = quantidadesClients
    this.planetChartData2.data.datasets[0].label = currentYeir
    const ctx2 = document.getElementById('planet-chart2')
    new Chart(ctx2, this.planetChartData2)

  },
  methods: {
    async getChartData(ano){
      this.selected_ano_Cliente = ano
  //Get total vendas 
      const vendas_total  =
        await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + ano)
      const result_vendas_total  = await vendas_total.json();
      console.log("Rersult total vendas")
      console.log(result_vendas_total)

      //Get Vendas por mes
      var quantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
      const vendas_por_mes  =
        await fetch('https://localhost:44381/api/Vendas/VendasPorMes_Ano?ano=' + ano)
      const result_vendas_por_mes = await vendas_por_mes.json();
      console.log("quantidades")
      result_vendas_por_mes.forEach(element => {
        quantidades[element.mes - 1] = element.valor;
      });
      console.log(quantidades);

      //Get top clients
      var nomes = [];
      var quantidadesClients = [];

      const top_clientes  =
        await fetch('https://localhost:44381/api/Clientes/TopClientes_Ano?ano=' +ano)
      const result_top_clientes  = await top_clientes.json();
      console.log("nomes quantidades")
      result_top_clientes.forEach(element => {
        nomes.push(element.nome);
        quantidadesClients.push(element.valor);
      });
    
      console.log(nomes)
      this.clientsData = nomes
      console.log(quantidadesClients)
      //Update Chart
      this.planetChartData2.type = 'line'
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
      this.planetChartData.data.datasets[0].data = quantidades
      this.planetChartData.data.datasets[0].label = ano
      const ctx = document.getElementById('planet-chart')
      new Chart(ctx, this.planetChartData)

      //Plot 2 
      this.planetChartData2.type = 'bar'
      this.planetChartData2.data.labels =nomes
      this.planetChartData2.data.datasets[0].data = quantidadesClients
      this.planetChartData2.data.datasets[0].label = ano
      const ctx2 = document.getElementById('planet-chart2')
      new Chart(ctx2, this.planetChartData2)
    },

    async onClientSelected(client){
      console.log('Sem tretas no fetch')
      const faturas_clients_nome  =
       await fetch('https://localhost:44381/api/Faturas/Clientes_Nome_Ano?nome=' + client +'&ano=' + this.selected_ano_Total)
      const result = await faturas_clients_nome.json();
          var obj = this.$refs.accordionInc.ej2Instances
          var itemsData = [];
          var mapping = {header: 'id', content: 'cliente'};
          for(var i= 0; i < result.length; i++) {

          itemsData.push({ header: result[i][mapping.header], content: 'Cliente: <h4>'+result[i][mapping.content]+'</h4>' + 'Cliente ID: <h4>'+result[i].cliente_ID +'</h4>' +'Data: <h4>'+result[i].data +'</h4>' + 'Valor em euros: <h4>'+result[i].valor +'€</h4>'});
        }
        obj.items = itemsData;
        obj.refresh();
      
    },

    async onMonthSelected(mes){
        console.log(mes)
        console.log(this.selected_ano_Total)
         const faturas_clients_nome  =
       await fetch('https://localhost:44381/api/Faturas/Vendas_Ano_Mes?ano='
      + this.selected_ano_Total +'&mes=' +mes)
      const result = await faturas_clients_nome.json();

     // new DataManager({url: 'https://localhost:44381/api/Faturas/Vendas_Ano_Mes?ano='
     // + this.selected_ano_Total +'&mes=' +mes, adaptor: new ODataAdaptor})
     // .executeQuery(new Query().range(4, 7)).then((e) => {
         // var result = e.result;
          console.log(result)
          var obj = this.$refs.accordionInc2.ej2Instances
          var itemsData = [];
          var mapping = {header: 'id', content: 'cliente'};
          for(var i= 0; i < result.length; i++) {

          itemsData.push({ header: result[i][mapping.header], content: 'Cliente: '+result[i][mapping.content]+'<br />'+'cliente ID: '+result[i].cliente_ID +'<br />'+'data: '+result[i].data +'<br />'+'documento: '+result[i].documento +'<br />'+'valor em euros: '+result[i].valor +'€'});
        }

        obj.items = itemsData;
        obj.refresh();
    
    },
    async setSecundYear(selected_ano_Total2){
      var quantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
      const vendas_por_mes  =
        await fetch('https://localhost:44381/api/Vendas/VendasPorMes_Ano?ano=' + selected_ano_Total2)
      const result_vendas_por_mes = await vendas_por_mes.json();
      console.log("quantidades")
      result_vendas_por_mes.forEach(element => {
        quantidades[element.mes - 1] = element.valor;
      });
      console.log(quantidades);
     
      var newDataSet = {
        
        label: selected_ano_Total2,
        data: quantidades,
        backgroundColor: "rgba(75, 0, 130, 0.5)",
        borderColor: "rgba(75, 0, 130, 0.5)",
        borderWidth: 2
      
      }

      console.log("LEngth")
      console.log(this.planetChartData.data.datasets.length)
       if(this.planetChartData.data.datasets.length>1){
         
        this.planetChartData.data.datasets[1] = newDataSet
      }else{
        this.planetChartData.data.datasets.push(newDataSet)
      }
      
      const ctx = document.getElementById('planet-chart')
      new Chart(ctx, this.planetChartData)
    },
  }
}
</script>

<style scoped>
.chart-container {
    width: 70%;
    height:70%;
    padding-left: 80px;
}

.chart-container-align {
  text-align: left;
  padding-left: 80px;

}

.dropdown {
  text-align: left;
  padding-left: 200px;
  padding-right: 500px;
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
.accordion{

}

</style>