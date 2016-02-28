from pyftpdlib.authorizers import DummyAuthorizer
from pyftpdlib.handlers import FTPHandler
from pyftpdlib.servers import FTPServer

def main():
	authorizer = DummyAuthorizer()
	#authorizer.add_user("user", "12345", "/home/squadhome/nwhacks16/fergenstein", perm="elradfmw")
	authorizer.add_anonymous("/home/squadhome/nwhacks16/fergenstein/objects")

	handler = FTPHandler
	handler.authorizer = authorizer

	server = FTPServer(("127.0.0.1", 21), handler)
	server.serve_forever()

if __name__ == "__main__":
	main()
