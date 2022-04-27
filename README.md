MultiValueDictionary
MultiValueDictionary is an command line interactive application to accept multiple string values for a string key.

Tools Required
  Visual Studio 19 or newer
  .NET 5 SDK

* Arguments in command line are separated by blank space, for example ADD foo bar will be considered as three arguments.
  1) ADD
  2) foo
  3) bar
  - The above example performs ADD operation with foo as a key and bar as a value.
  - Operation commands case-insensitive, ADD, add, Add all will perform the same operation.
 
 Operations
  - KEYS --> requires no extra arguments
    -- Returns all the keys in the dictionary. Order is not guaranteed.
    -- Example: KEYS --> returns all the keys, will ignore commands after KEYS
    
  - MEMBERS --> requires one extra argument, it will be passed as a key
    -- Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exist.
    -- It takes one more command line argument, if it has less than total 2 command line argument, it will show "invalid command".
    -- Example: MEMBERS foo
  
  - ADD --> requires 2 extra arguments, 1st one is key, 2nd one is value
    -- Adds a member to a collection for a given key. Displays an error if the member already exists for the key.
    -- Example: ADD foo bar
  
  - Remove --> requires 2 extra arguments, 1st one is key, 2nd one is value to be removed
    -- Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, dispay an error.
    -- Example: REMOVE foo bar
  
  - REMOVEALL --> requires 1 extra argument for the key
    -- Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
    -- Example: REMOVEALL foo
    
  - CLEAR --> requires no extra argument.
    -- Removes all keys and all members from the dictionary.
    -- Example: CLEAR
    
  - KEYEXISTS --> requires 1 extra argument for the key
    -- Returns whether a key exists or not.
    -- Example: KEYEXISTS foo
    
  - MEMBEREXISTS --> requires 2 extra arguments, 1st one for the key, 2nd one for the member
    -- Returns whether a member exists within a key. Returns false if the key does not exist.
    -- Example: MEMBEREXISTS foo bar
 
  - ALLMEMBERS --> requires no extra arguments.
    -- Returns all the members in the dictionary. Returns nothing if there are none. Order is not guaranteed.
    -- Example: ALLMEMBERS
    
  - ITEMS --> requires no extra arguments.
    -- Returns all keys in the dictionary and all of their members. Returns nothin if there are none. Order is not        guaranteed.
    -- Example: ITEMS
    
  - EXIT --> requires no extra arguments
    -- It will prompt user with the confirmation message, user can select y/Yes to exit and n/No to stay (options are case-insensitive), if pressed anything else and entered then it will show the confirmation message again.
    -- Example: EXIT
