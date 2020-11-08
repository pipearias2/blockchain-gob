pragma solidity ^0.6.6;

contract Contract {
    
    string public guid;
    string public applicant;
    string public defendant;
    string public typeProcess;
    
    constructor(string memory newGuid, string memory newApplicant, string memory newDefendant, string memory newTypeProcess) public{
        guid = newGuid;
        applicant = newApplicant;
        defendant = newDefendant;
        typeProcess = newTypeProcess;
    }
}
