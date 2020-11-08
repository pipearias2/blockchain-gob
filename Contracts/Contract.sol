pragma solidity ^0.4.26;

contract Contract {
    
    string public guid;
    
    constructor(string newGuid) public{
        guid = newGuid;
    }
}
