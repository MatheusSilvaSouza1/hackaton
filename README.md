# Hackathon 4NETT

## 📌 Sobre o Projeto

A **Health&Med**, uma startup inovadora no setor de saúde, busca revolucionar a **Telemedicina** no país. Atualmente, a empresa utiliza soluções terceirizadas como **Google Agenda** e **Google Meetings** para o agendamento e realização de consultas online.

Após receber um aporte financeiro, a startup decidiu investir no desenvolvimento de um sistema **próprio**, com foco em **segurança, escalabilidade e redução de custos**. Para isso, contratou os alunos do curso **4NETT** para realizar a **análise do projeto, definição da arquitetura** e o **desenvolvimento do MVP**.

---

## 🎯 Objetivo

Criar um **sistema robusto e seguro** para o gerenciamento de consultas médicas online, permitindo que médicos e pacientes realizem agendamentos e interajam de maneira eficiente.

---

## 🏗️ Arquitetura da Solução

Para atender aos requisitos do projeto, desenvolvemos uma solução escalável e de alta disponibilidade, utilizando as seguintes tecnologias:

### 🔹 **Infraestrutura e Escalabilidade**

- **Kubernetes**: Gerencia a replicação da aplicação de forma horizontal, garantindo escalabilidade e resiliência.
- **Load Balancer**: Distribui as requisições entre os pods, garantindo um melhor balanceamento de carga.
- **AWS RDS**: Banco de dados escalável, permitindo a criação de instâncias de leitura conforme a necessidade.
- **Redis**: Implementado para cache, reduzindo a latência e otimizando o processamento de requisições.

---

## 📌 Requisitos Funcionais Implementados

- **Autenticação do Médico** (Login via CRM e senha)
- **Cadastro e Edição de Horários Disponíveis**
- **Aceite ou Recusa de Consultas**
- **Autenticação do Paciente** (Login via e-mail/CPF e senha)
- **Busca por Médicos** (Filtros por especialidade)
- **Agendamento de Consultas** (Visualização da agenda, valor da consulta e cancelamento com justificativa)

---

## 🔒 Requisitos Não Funcionais Atendidos

- **Alta Disponibilidade**: Uso de Kubernetes para garantir que o sistema esteja sempre operacional.
- **Escalabilidade**: Suporte para até **20.000 usuários simultâneos**.
- **Segurança**: Implementação de boas práticas para a proteção de dados sensíveis dos pacientes.

---

## 🚀 Entregáveis

1. **Desenho da Solução MVP**:
   - Arquitetura detalhada e justificativas técnicas.
   - Explicação sobre como os requisitos não funcionais são atendidos.
2. **Demonstração da Infraestrutura**:
   - Aplicação funcionando em ambiente controlado.
   - Exemplos reais de uso com chamadas de API.
3. **Demonstração da Esteira de CI/CD**:
   - Pipeline de deploy automatizado.
4. **Demonstração do MVP**:
   - Sistema funcional com os requisitos essenciais implementados.

---

## 🎥 Demonstração

Disponível na apresentação final do Hackathon.\
[https://youtu.be/jvxLh74q2yA](https://youtu.be/jvxLh74q2yA)



**#Hackathon4NETT #Health&Med #Telemedicina**

