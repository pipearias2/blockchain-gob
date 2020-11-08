using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Angular.Contracts.Contract.ContractDefinition;

namespace Angular.Contracts.Contract
{
    public partial class ContractService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ContractDeployment contractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ContractDeployment>().SendRequestAndWaitForReceiptAsync(contractDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ContractDeployment contractDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ContractDeployment>().SendRequestAsync(contractDeployment);
        }

        public static async Task<ContractService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ContractDeployment contractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, contractDeployment, cancellationTokenSource);
            return new ContractService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ContractService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ApplicantQueryAsync(ApplicantFunction applicantFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApplicantFunction, string>(applicantFunction, blockParameter);
        }

        
        public Task<string> ApplicantQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApplicantFunction, string>(null, blockParameter);
        }

        public Task<string> DefendantQueryAsync(DefendantFunction defendantFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefendantFunction, string>(defendantFunction, blockParameter);
        }

        
        public Task<string> DefendantQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefendantFunction, string>(null, blockParameter);
        }

        public Task<string> GuidQueryAsync(GuidFunction guidFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuidFunction, string>(guidFunction, blockParameter);
        }

        
        public Task<string> GuidQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuidFunction, string>(null, blockParameter);
        }

        public Task<string> TypeProcessQueryAsync(TypeProcessFunction typeProcessFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeProcessFunction, string>(typeProcessFunction, blockParameter);
        }

        
        public Task<string> TypeProcessQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeProcessFunction, string>(null, blockParameter);
        }
    }
}
