using Abp.Application.Services;
using Abp.Domain.Repositories;
using blockchainGob.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Angular.Contracts.Contract;
using Angular.Contracts.Contract.ContractDefinition;
using Nethereum.Web3.Accounts.Managed;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace blockchainGob.Services.Complaint
{
    public class ComplaintAppService : AsyncCrudAppService<Entities.Complaint, ComplaintDto, Guid>
    {
        public ComplaintAppService(IRepository<Entities.Complaint, Guid> repository) : base(repository)
        {
        }
        public override async Task<ComplaintDto> CreateAsync(ComplaintDto input)
        {
            validateTransaction(input);
            ComplaintDto complaint = await base.CreateAsync(input);
                 

            return complaint;
        }

        private async void validateTransaction(ComplaintDto input)
        {
            try
            {
                var inputRequest = new ComplaintRequestDto()
                {
                    NewApplicant = input.Applicant,
                    NewDefendant = input.Defendant,
                    NewGuid = input.Id.ToString(),
                    NewTypeProcess = input.TypeProcess.ToString()
                };
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://u1mj5i89xd-u1vfy33yzc-connect.us1-azure.kaleido.io/gateways/complaint/?kld-from=0x1f3f30734dcda9f511bbdcc6fe7ae174ab1d510d&kld-sync=true");
                AuthenticationHeaderValue authenticationHeader = new AuthenticationHeaderValue("Basic", "dTF3cW9nd2NoNjpWUTNKSGhQVW5MM1FXODZpRnhFeDdZc3BFYkRYNjVVajJFblpxZHRRRmFV");
                client.DefaultRequestHeaders.Authorization = authenticationHeader;
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new StringContent(JsonConvert.SerializeObject(inputRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(
                    client.BaseAddress, 
                    httpContent);



                // Setup
                // Here we're using local chain eg Geth https://github.com/Nethereum/TestChains#geth
                var url = "https://u1mj5i89xd-u1vfy33yzc-connect.us1-azure.kaleido.io/gateways/complaint/?kld-from=0x1f3f30734dcda9f511bbdcc6fe7ae174ab1d510d&kld-sync=true";


                var privateKey = "0x1f3f30734dcda9f511bbdcc6fe7ae174ab1d510d";
                var account = new Account(privateKey);
                var web3 = new Web3(account, url, null, authenticationHeader);

                //var senderAddress = "0x1f3f30734dcda9f511bbdcc6fe7ae174ab1d510d";
                //var password = "vqCEi3ZrhQE6LN6sy2TUCey5HzOXpmNcRL4hhIqcEU8";

                //var account = new ManagedAccount(senderAddress, password);

                //var account = new Account(privateKey);
                //var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new ContractDeployment();
                deployment.NewApplicant = "ANDRES";
                deployment.NewDefendant = "TOBIAS";
                deployment.NewGuid = "3FA85F64-5717-4562-B3FC-2C963F66AFA6";
                deployment.NewTypeProcess ="Civil";
                deployment.FromAddress = "0x1f3f30734dcda9f511bbdcc6fe7ae174ab1d510d";
                var receipt = await ContractService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new ContractService(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");

                //Console.WriteLine("Sending a transaction to the function set()...");
                //var receiptForSetFunctionCall = await service.DeployContractAndGetServiceAsync()
                //    .SetRequestAndWaitForReceiptAsync(
                //    new SetFunction() { X = 42, Gas = 400000 });
                //Console.WriteLine($"Finished storing an int: Tx Hash: {receiptForSetFunctionCall.TransactionHash}");
                //Console.WriteLine($"Finished storing an int: Tx Status: {receiptForSetFunctionCall.Status.Value}");
                //Console.WriteLine("");

                //Console.WriteLine("Calling the function get()...");
                //var intValueFromGetFunctionCall = await service.GetQueryAsync();
                //Console.WriteLine($"Int value: {intValueFromGetFunctionCall} (expecting value 42)");
                //Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
