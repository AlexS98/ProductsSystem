set -e
run_cmd="dotnet run"

until dotnet tool install --global dotnet-ef; do
>&2 echo "installing ef tools"
sleep 1
done

until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd