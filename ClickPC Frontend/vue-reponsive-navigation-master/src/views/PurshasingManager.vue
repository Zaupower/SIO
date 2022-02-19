<template>
    <div id="app">
      <h1>Purchasing Manager</h1>
      <h3>Total despesas para o ano {{selected_ano_Total}}: {{total_despesas_do_ano}}€ </h3>
      <div class="chart-container">

         <ejs-dropdownlist id='dropdownlist' v-model="selected_ano_Total" @change="getChartData(selected_ano_Total)" placeholder='Selecione um ano'  :dataSource='anos'></ejs-dropdownlist>  
              <ejs-dropdownlist id='dropdownlist' v-model="selected_ano_Total2" @change="setSecundYear(selected_ano_Total2)" placeholder='Selecione segundo ano'  :dataSource='anos'></ejs-dropdownlist>
            
              <h3>Despesas por mes</h3>
            <canvas id="purchasing-chart"></canvas>

<br>
        <h3>Top Produtos Comprados num ano</h3>
             <ejs-dropdownlist id='dropdownlist4' :placeholder=' "Selecionar um mes do ano  " + selected_ano_Total '  :dataSource='meses_select' :fields='fields'  v-model="mes_select" @change="onMonthSelectedP(mes_select)"></ejs-dropdownlist>
       

       
         <ejs-accumulationchart id="container">
            <e-accumulation-series-collection>
                <e-accumulation-series :dataSource='seriesData' xName='x' yName='y' :dataLabel='datalabel' radius='90%'> </e-accumulation-series>
            </e-accumulation-series-collection>
        </ejs-accumulationchart>

        <h3>Faturas de despesas</h3>
    
      <ejs-dropdownlist id='dropdownlist5' :placeholder=' "Selecionar um mes do ano  " + selected_ano_Total '  :dataSource='meses_select' :fields='fields'  v-model="mes_select" @change="getFaturasDespesas(mes_select)"></ejs-dropdownlist>
       
        <div class="accordion">
          <ejs-accordion ref="accordionIncp">
          </ejs-accordion>
        </div>
      </div>
    <br>
    </div>
</template>
<script>
import { AccordionPlugin } from '@syncfusion/ej2-vue-navigations';
import Chart from 'chart.js'
import purchasingChartData from '../purchasing-chart.js';

import Vue from "vue";

import { AccumulationChartPlugin, PieSeries, AccumulationLegend, AccumulationDataLabel    } from "@syncfusion/ej2-vue-charts";
import { DropDownListPlugin } from "@syncfusion/ej2-vue-dropdowns";

Vue.use(AccordionPlugin);
Vue.use(AccumulationChartPlugin);
Vue.use(DropDownListPlugin);
export default {
  data() {
    return {
      purchasingChartData: purchasingChartData,
      anos: [ new Date().getFullYear(), new Date().getFullYear()-1, new Date().getFullYear() - 2, new Date().getFullYear() - 3],
      selected_ano_Total: new Date().getFullYear(),
      total_despesas_do_ano: 0,
      meses_select: [
      { Id: '-1', Mes_select: 'Ano Total' },
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
    seriesData: [],
            datalabel: { visible: true, name: 'label' },
            legendSettings:{fontWeight:990, position:'Top' ,alignment:'Near'},
            pointColorMapping: 'fill'
        };
  },
  async mounted () {
    //Get total despesas de um dado ano
    const total_despesas_ano  =
      await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + this.selected_ano_Total)
    const result_total_despesas_ano = await total_despesas_ano.json();
    this.total_despesas_do_ano = result_total_despesas_ano
    //Get despesas mes/Ano
    //Get Vendas por mes
    console.log('Get line chart on mounted')
    console.log(this.selected_ano_Total)
    this.selected_ano_Total =  new Date().getFullYear()
    var quantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    const vendas_por_mes  =
      await fetch('https://localhost:44381/api/Despesas/DespesasPorMes_Ano?ano=' + this.selected_ano_Total)
    const result_vendas_por_mes = await vendas_por_mes.json();
    console.log("quantidades")
    result_vendas_por_mes.forEach(element => {
      quantidades[element.mes - 1] = element.valor;
    });
    console.log(quantidades);
    this.purchasingChartData.data.datasets[0].data = quantidades
    this.purchasingChartData.data.datasets[0].label = new Date().getFullYear()
    const ctx11 = document.getElementById('purchasing-chart')
    new Chart(ctx11, this.purchasingChartData)

    //Get Pie chart
    console.log('Get pie chart on mounted')
    var arrayResult = []
    var chart = document.getElementById('container').ej2_instances[0];
    const productos_of_the_month  =
        await fetch('https://localhost:44381/api/Produtos/Top5ProductosVendidos_Ano?ano=' + this.selected_ano_Total)
      const result_productos_of_the_month = await productos_of_the_month.json();
      
      result_productos_of_the_month.forEach(element => {
        var tmp = {
           x: element.description,
           y: element.quantidade,
           fill: '#498fff',
           text:element.description, 
           label:element.quantidade }
        arrayResult.push(tmp)
      });
    console.log(arrayResult)
    chart.series[0].dataSource = arrayResult;
    chart.refresh();
  },
  methods:{
    async getChartData(selected_ano_Total){
      
      

      //Get total despesas do ano
    const total_despesas_ano  =
      await fetch('https://localhost:44381/api/Despesas/Total_Ano?ano=' + selected_ano_Total)
    const result_total_despesas_ano = await total_despesas_ano.json();
    this.total_despesas_do_ano = result_total_despesas_ano


    var quantidades = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
      const vendas_por_mes  =
        await fetch('https://localhost:44381/api/Vendas/VendasPorMes_Ano?ano=' + selected_ano_Total)
      const result_vendas_por_mes = await vendas_por_mes.json();
      console.log("quantidades")
      result_vendas_por_mes.forEach(element => {
        quantidades[element.mes - 1] = element.valor;
      });
      console.log(quantidades);
     
      var newDataSet = {
        
        label: selected_ano_Total,
        data: quantidades,
        backgroundColor: "rgba(71, 183,132,.5)",
        borderColor: "rgba(71, 183,132,.5)",
        borderWidth: 2
      
      }
      this.purchasingChartData.data.datasets[0] = newDataSet
      const ctx13 = document.getElementById('purchasing-chart')
      new Chart(ctx13, this.purchasingChartData)
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
      console.log(this.purchasingChartData.data.datasets.length)
       if(this.purchasingChartData.data.datasets.length>1){
         
        this.purchasingChartData.data.datasets[1] = newDataSet
      }else{
        this.purchasingChartData.data.datasets.push(newDataSet)
      }
      
      const ctx13 = document.getElementById('purchasing-chart')
      new Chart(ctx13, this.purchasingChartData)
    },
    async onMonthSelectedP(mes_select){
    if(mes_select != -1){
      var arrayResult = []
      console.log(mes_select)
      var chart = document.getElementById('container').ej2_instances[0];
      const productos_of_the_month  =
        await fetch('https://localhost:44381/api/Produtos/Top5ProductosVendidos_Ano_Mes?ano=' + this.selected_ano_Total + '&mes=' + mes_select )
      const result_productos_of_the_month = await productos_of_the_month.json();
      
      result_productos_of_the_month.forEach(element => {
        var tmp = {
           x: element.description,
           y: element.quantidade,
           fill: '#498fff',
           text:element.description, 
           label:element.quantidade }
        arrayResult.push(tmp)
      });
      console.log(arrayResult)
      chart.series[0].dataSource = arrayResult;
      chart.refresh();
    }else{
       console.log('Get pie chart on mounted')
    var arrayResult = []
    var chart = document.getElementById('container').ej2_instances[0];
    const productos_of_the_month  =
        await fetch('https://localhost:44381/api/Produtos/Top5ProductosVendidos_Ano?ano=' + this.selected_ano_Total)
      const result_productos_of_the_month = await productos_of_the_month.json();
      
      result_productos_of_the_month.forEach(element => {
        var tmp = {
           x: element.description,
           y: element.quantidade,
           fill: '#498fff',
           text:element.description, 
           label:element.quantidade }
        arrayResult.push(tmp)
      });
    console.log(arrayResult)
    chart.series[0].dataSource = arrayResult;
    chart.refresh();
    }
    },
    async getFaturasDespesas(mes){
      console.log(mes)
      const faturas_despesas_mes  =
       await fetch('https://localhost:44381/api/Faturas/Despesas_Ano_Mes?ano=' + this.selected_ano_Total +'&mes=' + mes)
      const result = await faturas_despesas_mes.json();
          var obj = this.$refs.accordionIncp.ej2Instances
          var itemsData = [];
          var mapping = {header: 'id', content: 'cliente'};
          for(var i= 0; i < result.length; i++) {

          itemsData.push({ header: result[i][mapping.header], content: '<h3>Data: </h3>'+ ' <h2> '+ result[i].data +' </h2> '+'<h3>Documento: </h3>' +' <h2> '+result[i].documento +' </h2> ' +' <h3>Valor em euros: </h3>'+ ' <h2> '+result[i].valor +'€' +' </h2> '});
        }
        obj.items = itemsData;
        obj.refresh();
    }
  },
  provide: {
     accumulationchart: [PieSeries, AccumulationLegend, AccumulationDataLabel ]
  }
};
</script>
<style>

 .chart-container {
    width: 70%;
    height:70%;
    align-content: center;
    padding-left: 15%;
}
</style>